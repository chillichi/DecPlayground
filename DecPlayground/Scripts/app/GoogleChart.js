google.load("visualization", "1", { packages: ["corechart"] });
google.setOnLoadCallback(drawChart);

function drawChart() {

    $.post(pieChartUrl, {},
    function (data) {
        var tdata = new google.visualization.DataTable();
        console.log(data);
        tdata.addColumn('string', 'TrueOrFalse');
        tdata.addColumn('number', 'HeadCount');

        for (var i = 0; i < data.length; i++) {
            tdata.addRow([data[i].TrueOrFalse, data[i].HeadCount]);
        }

        var options = {
            title: "Google Chart"
        };

        var chart = new google.visualization.PieChart(document.getElementById('piechart'));
        chart.draw(tdata, options);
    });

}