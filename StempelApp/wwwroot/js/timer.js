import { getLocation } from './gps.js';
class Stopwatch {
    constructor(display) {
        this.timedTime = 0;
        this.paused = true;
        this.lastLoop = Date.now();
        this.display = display;
        this.updateLoop();
    }
    start() { this.paused = false; }
    stop(callback) {
        this.paused = true;
        if (callback) {
            getLocation().then(position => {
                callback(position);
            }).catch(err => {
                console.error("Fehler beim Abrufen der GPS-Daten:", err);
            });
        }
    }
    reset() { this.paused = true; this.timedTime = 0; this.updateDisplay(); }
    isRunning() {
        return !this.paused;
    }
    updateLoop() {
        const now = Date.now();
        if (!this.paused) {
            this.timedTime += now - this.lastLoop;
        }
        this.lastLoop = now;
        this.updateDisplay();
        requestAnimationFrame(() => this.updateLoop());
    }
    updateDisplay() {
        const sek = Math.floor((this.timedTime / 1000) % 60);
        const min = Math.floor((this.timedTime / (1000 * 60)) % 60);
        const std = Math.floor(this.timedTime / (1000 * 60 * 60));
        //this.display.innerText =
        //    `${String(std).padStart(2, '0')}:${String(min).padStart(2, '0')}:${String(sek).padStart(2, '0')}`;
        this.display.innerText =
            this.pad(std) + ":" + this.pad(min) + ":" + this.pad(sek);
    }
    pad(num, size = 2) {
        let s = String(num);
        while (s.length < size)
            s = "0" + s;
        return s;
    }
}
// const display = document.getElementById("zeiterfassung");
// if (display) {
//     const timer = new Stopwatch(display);
// 
//     const startBtn = document.getElementById("startBtn");
//     const pauseBtn = document.getElementById("stopBtn");
//     //const resetBtn = document.getElementById("resetBtn");
// 
//     startBtn?.addEventListener("click", () => timer.start());
//     pauseBtn?.addEventListener("click", () => timer.stop());
//     //resetBtn?.addEventListener("click", () => timer.reset());
// }
const display = document.getElementById("zeiterfassung");
if (display) {
    const timer = new Stopwatch(display);
    const toggleBtn = document.getElementById("toggleBtn");
    toggleBtn.addEventListener("click", () => {
        if (timer.isRunning()) {
            timer.stop();
            toggleBtn.textContent = "Start";
        }
        else {
            timer.start();
            toggleBtn.textContent = "Pause";
        }
    });
}
//# sourceMappingURL=timer.js.map