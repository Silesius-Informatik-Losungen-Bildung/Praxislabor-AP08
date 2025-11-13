async function fetchResult(url) {
    try {
        const res = await fetch(url);
        if (!res.ok) {
            return { status: "error", message: `HTTP ${res.status}` };
        }
        const json = await res.json();
        return { status: "success", data: json };
    }
    catch (e) {
        return { status: "error", message: e.message ?? "Unknown error" };
    }
}
export async function apiFetch(path) {
    const base = window.APP_CONFIG.apiBase.replace(/\/$/, "");
    const url = `${base}/${path.replace(/^\//, "")}`;
    return fetchResult(url);
}
export function matchResult(result, handlers) {
    switch (result.status) {
        case "success":
            return handlers.success(result.data);
        case "error":
            return handlers.error
                ? handlers.error(result.message)
                : (() => { throw new Error(result.message); })();
        case "loading":
            return handlers.loading ? handlers.loading() : undefined;
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
//# sourceMappingURL=api.js.map