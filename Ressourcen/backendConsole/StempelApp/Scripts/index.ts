export * from './global/config.js';
export * from './global/api.js';
export * from './global/ui.js';

import { initUI } from './global/ui.js';

document.addEventListener("DOMContentLoaded", () => {
    initUI();
});