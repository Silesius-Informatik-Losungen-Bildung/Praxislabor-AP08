export interface GpsData {
    latitude: number;
    longitude: number;
}

export async function getLocation(): Promise<GpsData> {
    return new Promise((resolve, reject) => {
        if (!navigator.geolocation) {
            reject(new Error("Geolocation nicht unterstützt"));
            return;
        }

        navigator.geolocation.getCurrentPosition(
            (position) => {
                resolve({
                    latitude: position.coords.latitude,
                    longitude: position.coords.longitude,
                });
            },
            (error) => reject(error)
        );
    });
}