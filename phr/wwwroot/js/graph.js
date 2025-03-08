document.addEventListener('DOMContentLoaded', function () {
    const jsonArray = document.getElementById('chartData').textContent;
    const chartData = JSON.parse(jsonArray);

    if (chartData != null) {
        document.getElementById('loading').style.display = 'none';
    }
    
    var dates = chartData.map(data => data.testDate);
    var fluids = chartData.map(data => data.allocFluid);
    var oils = chartData.map(data => data.allocOil);
    var jobCodes = chartData.map(data => data.jobCode);
    
    const datasets1 = [{
        name: "(L1) Alloc Fluid",
        data: fluids.slice(1),
        color: "rgba(54, 162, 235, 1)",
        type: "line",
        axis: "y2"
    },
    {
        name: "(L3) Alloc Oil",
        data: oils.slice(1),
        color: "#C2D434",
        type: "line",
        axis: "y1"
    }];

    const jobCode1 = dates.slice(1).map((date, index) => {
        return jobCodes[index + 1] !== "" ? 19 : null;
    });

    if (jobCodes.some(value => value !== null)) {
        datasets1.push({
            name: "Annot.jobs",
            data: jobCode1,
            color: "#CF2031",
            type: "line",
            axis: "y3Job",
            markers: {
                visible: true,
                background: "#CF2031",
            },
            tooltip: {
                visible: true,
                template: function (e) {
                    return jobCodes.find(value => value !== "");
                }
            }
        });
    }

    const dates2 = ['2023-01-01', '2023-01-02', '2023-01-03', '2023-01-04', '2023-01-05', '2023-01-06'];
    const datasets2 = [
        {
            name: '(L1) Alloc Fluid',
            data: [200, 250, 300, 280, 350, 420], 
            color: 'rgba(54, 162, 235, 1)',
            axis: 'y2',
            type: 'line'
        },
        {
            name: '(L1) PumpFill',
            data: [10, 20, 35, 40, 50, 60], 
            color: '#C2D434',
            axis: 'y1',
            type: 'line'
        },
        {
            name: '(L1) PumpSlip',
            data: [5, 10, 15, 20, 30, 45], 
            color: '#CF2031',
            axis: 'y1',
            type: 'line'
        },
        {
            name: '(L2) WHP',
            data: [15, 30, 50, 70, 90, 120],
            color: '#00BFFF',
            axis: 'y1',
            type: 'line'
        },
        {
            name: '(L2) TubingPress',
            data: [20, 25, 30, 35, 40, 45], 
            color: '#00008B',
            axis: 'y1',
            type: 'line'
        },
        {
            name: '(L2) CsgPressUp',
            data: [10, 12, 15, 18, 22, 28], 
            color: '#FF0C0C',
            axis: 'y1',
            type: 'line'
        },
        {
            name: '(L2) Ampere',
            data: [5, 8, 12, 18, 25, 30],
            color: '#8D0303',
            axis: 'y1',
            type: 'line'
        },
        {
            name: '(L2) Amp(SCADA)',
            data: [8, 15, 20, 25, 28, 35], 
            color: '#FF9900',
            axis: 'y1',
            type: 'line'
        },
        {
            name: '(L3) Alloc Oil',
            data: [50, 60, 75, 80, 95, 110],
            color: '#73C100',
            axis: 'y1',
            type: 'line'
        },
        {
            name: '(L3) Mtr Winding',
            data: [30, 40, 50, 60, 70, 85], 
            color: '#EC5800',
            axis: 'y1',
            type: 'line'
        },
        {
            name: '(L3) Bottom Hole',
            data: [20, 25, 30, 35, 40, 50], 
            color: '#ED6778',
            axis: 'y1',
            type: 'line'
        }
    ];

    
    function createOrUpdateChart(chartId, scaleType, datasets, categories) {
        const dataCount = categories.length;
        
        let step = 1, rotation = 0;
        if (dataCount > 10) {
            step = Math.ceil(dataCount / 10);
            rotation = -45;
        }

        const chart = $("#" + chartId).data("kendoChart");
        if (chart) {
            chart.destroy();
        }
        
        $("#" + chartId).kendoChart({
            legend: {
                position: "top"
            },
            series: datasets,
            valueAxes: [
                {
                    name: "y2",
                    color: "rgba(54, 162, 235, 1)",
                    type: scaleType,
                },
                {
                    name: "y1",
                    color: "#C2D434",
                    type: scaleType,
                },
                {
                    name: "y3Job",
                    max: 20,
                },
            ],
            categoryAxis: {
                type: "date",
                categories: categories,
                title: {
                    text: "Date"
                },
                position: 'bottom',
                labels: {
                    step: step,
                    rotation: rotation,
                    format: "dd-MM-yyyy"
                },
            },
            tooltip: {
                visible: true,
                shared: true,
            }
        });
    }


    $(document).ready(function () {
        createOrUpdateChart("chart", "linear", datasets1, dates.slice(1));  
        createOrUpdateChart("chart2", "linear", datasets2, dates2);      

        $("#scaleSelector").on("change", function () {
            const selectedScale = $(this).val();
            createOrUpdateChart("chart", selectedScale, datasets1, dates.slice(1));
            createOrUpdateChart("chart2", selectedScale, datasets2, dates2);
        });
    });
});
