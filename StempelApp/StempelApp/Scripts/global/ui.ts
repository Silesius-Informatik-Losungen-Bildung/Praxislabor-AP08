export function initUI() {
    const burgers = document.querySelectorAll<HTMLElement>('.navbar-burger');
    burgers.forEach(burger => {
        burger.addEventListener('click', () => {
            const targetId = burger.dataset.target;
            if (!targetId) return;
            const target = document.getElementById(targetId);
            burger.classList.toggle('is-active');
            target?.classList.toggle('is-active');
        });
    });

    const headers = document.querySelectorAll('.accordion-header');
    headers.forEach(header => {
        header.addEventListener('click', () => {
            const content = header.nextElementSibling as HTMLElement;
            content.classList.toggle('open');
        });
    });
}