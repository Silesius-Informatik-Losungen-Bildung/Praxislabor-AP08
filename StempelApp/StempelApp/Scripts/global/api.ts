export type ApiResult<T> =
    | { status: "success"; data: T }
    | { status: "error"; message: string }
    | { status: "loading" };

async function fetchResult<T>(url: string): Promise<ApiResult<T>> {
    try {
        const res = await fetch(url);
        if (!res.ok) {
            return { status: "error", message: `HTTP ${res.status}` };
        }
        const json = await res.json();
        return { status: "success", data: json as T };
    } catch (e: any) {
        return { status: "error", message: e.message ?? "Unknown error" };
    }
}

export async function apiFetch<T>(path: string): Promise<ApiResult<T>> {
    const base = window.APP_CONFIG.apiBase.replace(/\/$/, "");
    const url = `${base}/${path.replace(/^\//, "")}`;
    return fetchResult<T>(url);
}
export function matchResult<T, R>(
    result: ApiResult<T>,
    handlers: {
        success: (data: T) => R;
        error?: (message: string) => R;
        loading?: () => R;
    }
): R {
    switch (result.status) {
        case "success":
            return handlers.success(result.data);
        case "error":
            return handlers.error
                ? handlers.error(result.message)
                : (() => { throw new Error(result.message); })();
        case "loading":
            return handlers.loading ? handlers.loading() : (undefined as any);
    }
}

//export function handleResult<T>(result: ApiResult<T>) : T | undefined {
//    switch (result.status) {
//        case "success":
//            console.log("Data:", result.data);
//            return result.data;
//        case "error":
//            console.error("Error:", result.message);
//            return undefined;
//        case "loading":
//            console.log("loding...")
//            return undefined;
//    }