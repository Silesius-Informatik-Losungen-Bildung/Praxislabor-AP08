//import { ChartData } from './ChartData.js';
import { matchResult, apiFetch, ApiResult } from './index.js'
declare var google: any;

interface ChartResponse {
    groupBy: string;
    data: DataPoint[];
}

interface DataPoint {
    category: (string | number );
    amount: number;
}

class ChartDataTable {
    private rows: (string | number)[][];

    constructor(header: (string | number)[]) {
        this.rows = [header];
    }

    add(category: string | number, value: number) {
        this.rows.push([category, value]);
    }

    getData(): (string | number)[][] {
        return this.rows
    }
}

function isChartResponse(obj: any): obj is ChartResponse {
    return (
        obj &&
        typeof obj.groupBy === "string" &&
        Array.isArray(obj.data) &&
        obj.data.every(
            (d: any) =>
                (typeof d.category === "string" || typeof d.category === "number") &&
                typeof d.amount === "number"
        )
    );
}

google.charts.load('current', { packages: ['corechart'] });
google.charts.setOnLoadCallback(drawChart);

async function drawChart() {
    let res: ApiResult<ChartResponse>;
    if (window.APP_CONFIG.isDevelopment) {
        res  = {
            status: "success",
            data: {
                groupBy: "Jahr",
                data: [
                    { category: 2021, amount: 12000 },
                    { category: 2022, amount: 15000 },
                    { category: 2023, amount: 18000 },
                    { category: 2024, amount: 20000 }
                ]
            }
        };
    }
    else {
        res = await apiFetch<ChartResponse>("SalesApi");
        //const json: ValidChartResponse = await ChartResponseSchema.parse(res);
    }

    matchResult(res, {
        loading: () => window.APP_CONFIG.enableLogging && console.log("Lade Daten..."),
        error: msg => console.error("Fehler beim Laden:", msg),
        success: json => createChart(json),
    });
}

function createChart(json: ChartResponse): void {
    const chartData = new ChartDataTable([json.groupBy, 'Umsatz']);
    json.data.forEach((s) => chartData.add(s.category.toString(), s.amount));

    const dataTable = google.visualization.arrayToDataTable(chartData.getData());
    const options = {
        title: `Umsatz pro ${json.groupBy}`,
        legend: { position: 'none' },
        hAxis: { title: 'Umsatz' },
        vAxis: { title: json.groupBy }
    }

    const chart = new google.visualization.LineChart(document.getElementById('chart_div'));
    chart.draw(dataTable, options);
}