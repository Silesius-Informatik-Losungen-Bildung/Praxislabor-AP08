export interface AppConfig {
    apiBase: string;
    pageSize: number;
    enableLogging: boolean;
    dateFormat: string;
    defaultSort: string;
    isDevelopment: boolean;
    userEmail?: string;
}

declare global {
    interface Window {
        APP_CONFIG: AppConfig;
    }
}

window.APP_CONFIG = {
    apiBase: `${window.location.origin}/api`,
    pageSize: 15,
    enableLogging: true,
    dateFormat: "dd.MM.yyyy",
    defaultSort: "asc",
    isDevelopment: true,
};