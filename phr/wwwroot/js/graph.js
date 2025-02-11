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

	const dataCount = chartData.length;
	let step = 1;
	let rotation = 0; 
	if (dataCount > 10) {
		step = Math.ceil(dataCount / 10);
		rotation = -45; 
	}

	const datasets = [{
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
	const jobCode = dates.slice(1).map((date, index) => {
		return jobCodes[index + 1] !== "" ? 0 : null;
	});
	if (jobCodes.some(value => value !== null)) {
		datasets.push({
			name: "Annot.jobs",
			data: jobCode,
			color: "#CF2031",
			type: "line",
			axis: "y3",
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

	$(document).ready(function () {
		$("#chart").kendoChart({
			legend: {
				position: "top"
			},
			series: datasets,
			valueAxes: [
				{
					name: "y1",
					color: "#C2D434",
				},
				{
					name: "y2",
					color: "rgba(54, 162, 235, 1)",
				},
				{
					name: "y3",
					color: "#CF2031"
				}
			],
			categoryAxis: {
				type: "date",
				categories: dates.slice(1),
				title: {
					text: "Date"
				},
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
	});

	const categories = [
		'2023-01-01',
		'2023-01-02',
		'2023-01-03',
		'2023-01-04',
		'2023-01-05',
		'2023-01-06'
	];
	const dataCount2 = categories.length;
	let step2 = 1;
	let rotation2 = 0;
	if (dataCount2 > 10) {
		step2 = Math.ceil(dataCount2 / 10);
		rotation2 = -45;
	}

	$(document).ready(function () {
		$("#chart2").kendoChart({
			legend: {
				position: "top"
			},
			series: [
				{
					name: '(L1) Alloc Fluid',
					data: [250, 450, 600, 350, 550, 800],
					color: 'rgba(54, 162, 235, 1)',
					axis: 'y2',
					type: 'line'
				},
				{
					name: '(L1) PumpFill',
					data: [20, 70, 40, 10, 60, 120],
					color: '#C2D434',
					axis: 'y1',
					type: 'line'
				},
				{
					name: '(L1) PumpSlip',
					data: [15, 25, 20, 30, 45, 80],
					color: '#CF2031',
					axis: 'y3',
					type: 'line'
				},
				{
					name: '(L2) WHP',
					data: [5, 20, 15, 35, 50, 90],
					color: '#00BFFF',
					axis: 'y3',
					type: 'line'
				},
				{
					name: '(L2) TubingPress',
					data: [12, 18, 25, 30, 40, 70],
					color: '#00008B',
					axis: 'y3',
					type: 'line'
				},
				{
					name: '(L2) CsgPressUp',
					data: [8, 12, 20, 28, 38, 60],
					color: '#FF0C0C',
					axis: 'y3',
					type: 'line'
				},
				{
					name: '(L2) Ampere',
					data: [5, 10, 15, 20, 25, 30],
					color: '#8D0303',
					axis: 'y3',
					type: 'line'
				},
				{
					name: '(L2) Amp(SCADA)',
					data: [10, 15, 20, 25, 30, 35],
					color: '#FF9900',
					axis: 'y3',
					type: 'line'
				},
				{
					name: '(L3) Alloc Oil',
					data: [30, 40, 50, 60, 70, 80],
					color: '#73C100',
					axis: 'y3',
					type: 'line'
				},
				{
					name: '(L3) Mtr Winding',
					data: [5, 15, 25, 35, 45, 55],
					color: '#EC5800',
					axis: 'y3',
					type: 'line'
				},
				{
					name: '(L3) Bottom Hole',
					data: [10, 20, 30, 40, 50, 60],
					color: '#ED6778',
					axis: 'y3',
					type: 'line'
				}
			],
			valueAxes: [
				{
					name: "y1",
					color: "#C2D434"
				},
				{
					name: "y2",
					color: "rgba(54, 162, 235, 1)"
				},
				{
					name: "y3",
					color: "#CF2031"
				}
			],
			categoryAxis: {
				categories: categories,
				title: {
					text: "Date"
				},
				type: "date",
				labels: {
					step: step2,
					rotation: rotation2,
					format: "dd-MM-yyyy"
				}
			},
			tooltip: {
				visible: true,
				shared: true
			}
		});
	});

});