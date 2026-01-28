export function paginate<T>(items: T[], page: number, pageSize: number): T[] {
    const start = (page - 1) * pageSize;
    return items.slice(start, start + pageSize);
}
export function totalPages<T>(items: T[], pageSize: number): number {
    return Math.ceil(items.length / pageSize);
}

export function renderPaginationControls(
    currentPage: number,
    totalPages: number,
    onPageChange: (page: number) => void) {
    const container = document.getElementById('pagination');
    if (!container) return;

    container.innerHTML = '';
    for (let i = 1; i <= totalPages; i++) {
        const btn = document.createElement('button');
        btn.textContent = i.toString();
        btn.disabled = i === currentPage;
        btn.addEventListener('click', () => onPageChange(i));
        container.appendChild(btn);
    }
}