import { GpsData, getLocation } from './gps.js'

class Stopwatch {
    private timedTime: number = 0;
    private paused: boolean = true;
    private lastLoop: number = Date.now();
    private display: HTMLElement;

    constructor(display: HTMLElement) {
        this.display = display;
        this.updateLoop();
    }

    start() { this.paused = false; }
    stop(callback?: (pos: GpsData) => void) {
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

    private updateLoop() {
        const now = Date.now();
        if (!this.paused) {
            this.timedTime += now - this.lastLoop;
        }
        this.lastLoop = now;
        this.updateDisplay();
        requestAnimationFrame(() => this.updateLoop());
    }

    private updateDisplay() {
        const sek = Math.floor((this.timedTime / 1000) % 60);
        const min = Math.floor((this.timedTime / (1000 * 60)) % 60);
        const std = Math.floor(this.timedTime / (1000 * 60 * 60));

        //this.display.innerText =
        //    `${String(std).padStart(2, '0')}:${String(min).padStart(2, '0')}:${String(sek).padStart(2, '0')}`;

        this.display.innerText =
            this.pad(std) + ":" + this.pad(min) + ":" + this.pad(sek);
    }

    private pad(num: number, size: number = 2): string {
        let s = String(num);
        while (s.length < size) s = "0" + s;
        return s;
    }
}

const display = document.getElementById("zeiterfassung");
if (display) {
    const timer = new Stopwatch(display);

    const startBtn = document.getElementById("startBtn");
    const pauseBtn = document.getElementById("stopBtn");
    //const resetBtn = document.getElementById("resetBtn");

    startBtn?.addEventListener("click", () => timer.start());
    pauseBtn?.addEventListener("click", () => timer.stop());
    //resetBtn?.addEventListener("click", () => timer.reset());
}
