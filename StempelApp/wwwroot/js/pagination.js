export function paginate(items, page, pageSize) {
    const start = (page - 1) * pageSize;
    return items.slice(start, start + pageSize);
}
export function totalPages(items, pageSize) {
    return Math.ceil(items.length / pageSize);
}
export function renderPaginationControls(currentPage, totalPages, onPageChange) {
    const container = document.getElementById('pagination');
    if (!container)
        return;
    container.innerHTML = '';
    for (let i = 1; i <= totalPages; i++) {
        const btn = document.createElement('button');
        btn.textContent = i.toString();
        btn.disabled = i === currentPage;
        btn.addEventListener('click', () => onPageChange(i));
        container.appendChild(btn);
    }
}
//# sourceMappingURL=pagination.js.map