import { apiFetch, matchResult } from './index.js';
import { paginate, renderPaginationControls, totalPages } from './pagination.js';

interface Project {
    CustomerName: string;
    StartTime: string;
    Address: string;
}

interface ProjectListResponse {
    projects: Project[];
}
//ptr_8FpKLVV9wxYt + H + oQ8zGqrECVMxspxVF92wkzz42O2s=
// Hilfsfunktion für Datum-Formatierung
function formatDate(dateStr: string) {
    const date = new Date(dateStr);
    // dd.MM.yyyy HH:mm
    const day = String(date.getDate()).padStart(2, '0');
    const month = String(date.getMonth() + 1).padStart(2, '0');
    const year = date.getFullYear();
    const hours = String(date.getHours()).padStart(2, '0');
    const minutes = String(date.getMinutes()).padStart(2, '0');
    return `${day}.${month}.${year} ${hours}:${minutes}`;
}

function renderProjectsPage(projects: ProjectListResponse, currentPage: number) {
    const pageSize = window.APP_CONFIG.pageSize;
    const pageData = paginate(projects.projects, currentPage, pageSize);
    const pages = totalPages(projects.projects, pageSize);

    const container = document.getElementById('project-list');
    if (!container) return;

    container.innerHTML = '';

    pageData.forEach(project => {
        const div = document.createElement('div');
        div.className = 'accordion mb-4';
        div.innerHTML = `
            <div class="accordion-header" tabindex="0" style="display: flex; justify-content: space-between; cursor: pointer;">
                <span>${project.CustomerName}</span>
                <span>${formatDate(project.StartTime)}</span>
            </div>
            <div class="accordion-content" style="display:none; padding: 0.5rem 1rem; border: 1px solid #ccc; border-top: none;">
                <h4>Adresse</h4>
                <p>${project.Address}</p>
                <form action="/StempelApp/WorkList" method="get">
                    <input type="hidden" name="userEmail" value="${window.APP_CONFIG.userEmail || ''}" />
                    <button type="submit" class="button is-primary">Aufgabe</button>
                </form>
            </div>
        `;
        container.appendChild(div);
    });

    container.addEventListener('click', (e) => {
        const header = (e.target as HTMLElement).closest('.accordion-header');
        if (!header) return;
        const content = header.nextElementSibling as HTMLElement;
        content.style.display = content.style.display === 'none' ? 'block' : 'none';
    });


    renderPaginationControls(currentPage, pages, (newPage) => {
        renderProjectsPage(projects, newPage);
        container.scrollIntoView({ behavior: 'smooth' });
    });
}

async function loadProjects() {
    const res = await apiFetch<ProjectListResponse>('ProjectsApi');

    matchResult(res, {
        success: projects => renderProjectsPage(projects, 1),
        error: msg => window.APP_CONFIG.enableLogging && console.error(msg),
        loading: () => window.APP_CONFIG.enableLogging && console.log('Lade Projekte...')
    });
}

document.addEventListener('DOMContentLoaded', loadProjects);