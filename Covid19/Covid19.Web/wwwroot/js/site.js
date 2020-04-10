!(function ($) {
    "use strict";

    __();

    $(".card").addClass("hoverable");

    $("#btn-trigger-contacto").on("click", function () {
        $("#modal-contacto").modal();
    });

    var select = "<option selected value=''>Select day</option>";
    for (var i = 1; i < 32; i++) {
        select += '<option value="'+i+'">'+i+'</option>';

    }

    $("#select_day").html(select);


    $("#btn-account-login").on("click", function () {
        var url = $(this).data("url");
        var title = $(this).data("title");

        $.ajax({
            url: url,
            type: "get",
            success: function (response) {
                $("#modal-account .modal-title").html(title);
                $("#modal-account .modal-body").html(response);
                $("#modal-account").modal("open");
            }
        })
    });

    $("#btn-tls-load-graph-data").on("change", function () {
        var selected_val = $(this).val();

        if (selected_val == 1) {
            tls_get_municipio_graphic_data("/api/quarantines/group_by_municipio");
        } else if (selected_val == 2) {

        } else {
            toastr.info("Please select one option!");
        }
    });


    function tls_get_municipio_graphic_data(url) {
        $.ajax({
            url: url,
            type: "get",
            async: true,
            success: function (response) {
                tls_render_municipio_graphic_data(response);
            },
            error: function (error) {

                toastr.error("Error while getting data from /api/api/quarantines/group_by_municipio","Error");
            }
        });
    }//tls_get_municipio_graphic_data

    function tls_render_municipio_graphic_data(data) {
        
    }//tls_render_municipio_graphic_data


    $("#btn-load-tls-data").on("click", function () {
        var month = $("#select_month").val();
        var day = $("#select_day").val();

        if (month != "" && day != "") {

            var tls_url_graph = "/api/cases/2020/" + month + "/" + day;
            var tls_url_quarantine = "/api/quarantines/2020/" + month + "/" + day;
            tls_get_graph_data(tls_url_graph);
            tls_get_quarantine_data(tls_url_quarantine);
           
        } else {
            toastr.error("Please select month and date!","Error");

        }
    });

    tls_load_today_data();

    function tls_load_today_data() {
        tls_get_graph_data("/api/cases/today");
        tls_get_quarantine_data("/api/quarantines/today");
    }//tls_load_today_data

    function tls_get_graph_data(url) {
        $.ajax({
            url: url,
            type: "get",
            async: true,
            success: function (response) {
                tls_render_graph_header(response);
            },
            error: function (error) {
                toastr.error("Error while getting data from " + url,"Error");
            }
        });
    } //tls_get_graph

    function tls_get_quarantine_data(url) {
        $.ajax({
            url: url,
            type: "get",
            async: true,
            success: function (response) {
                tls_render_quarantine(response);
            },
            error: function (error) {
                toastr.error("Error while getting data from " + url,"Error");
            }
        });
    }//tls_get_quarantine


    function tls_render_graph_header(data) {
        var container = $("#today-tls-item-cases");
        var html = "";
        
        data.forEach(item => {

            switch (item.kazu) {
                case "SUSPEITU":
                    html += tls_create_div_today_item(item.kazu, item.total, "red lighten-1");
                    break;
                case "PROVAVEL":
                    html += tls_create_div_today_item(item.kazu, item.total, "green");
                    break;
                case "POSITIVU":
                    html += tls_create_div_today_item(item.kazu, item.total, "red");
                    break;
                case "NEGATIVU":
                    html += tls_create_div_today_item(item.kazu, item.total, "green accent-3");
                    break;
                case "REKUPERA":
                    html += tls_create_div_today_item(item.kazu, item.total, "green");
                    break;
                case "MATE":
                    html += tls_create_div_today_item(item.kazu, item.total, "red accent-4");
                    break;
            }
        });
        if (data.length > 0) {
            container.html(html);
        } else {;
            //toastr.info("<i>Please select the prefered date and month to be loaded</i>", "Information");
            Swal.fire({
                title: 'Information',
                html: "Today's data is not uploaded yet. Try again later!",
                icon: 'info'
            });
        }
        
    }//tls_render_graph_header


    function tls_render_quarantine(data) {
        var container = $("#today-tls-item-quarantine");
        var html = "";
        var totalKarantinaObrigatorio = 0, totalAutoKarantina = 0, totalPassaKarantina = 0, totalItems = 0;
        data.forEach(item => {
            html += '<tr>';
            html += '<td>' + formatNumber(item.munisipio) + '</td>';
            html += '<td>' + formatNumber(item.obrigatorio) + '</td>';
            html += '<td>' + formatNumber(item.auto) + '</td>';
            html += '<td>' + formatNumber(item.passa) + '</td>';

            var totalItem = (parseInt(item.obrigatorio) + parseInt(item.auto));
            totalKarantinaObrigatorio += parseInt(item.obrigatorio);
            totalAutoKarantina += parseInt(item.auto);
            totalPassaKarantina += parseInt(item.passa);
            totalItems += totalItem;


            html += '<td>' + formatNumber(totalItem) + '</td>';
            html += '</tr>';
        });

        if (data.length > 0) {
            html += '<tr>';
            html += '<td>Total</td>';
            html += '<td>' + formatNumber(totalKarantinaObrigatorio) + '</td>';
            html += '<td>' + formatNumber(totalAutoKarantina) + '</td>';
            html += '<td>' + formatNumber(totalPassaKarantina) + '</td>';
            html += '<td>' + formatNumber(totalItems) + '</td>';
            html += '</tr>';
            container.html(html);
        } else {
            Swal.fire({
                title: 'Information',
                html: "Today's data is not uploaded yet. Try again later!",
                icon: 'info'
            });
            //toastr.info("<i>Please select the prefered date and month to be loaded</i>", "Information");
        }
    }//tls_render_quarantine


    function tls_create_div_today_item(kazu, total, color) {
        var html = '<div class="col s12 m4"><div class="card ' + color + ' hoverable waves-effect waves-light"><div class="card-content">';
        html += '<span class=" ponto-actual-text">' + kazu + '</span> <br>';
        html += '<span class="ponto-actual-number">' + formatNumber(total) + '</span>';
        html += '</div></div></div>';

        return html;
    }//tls_create_div_today_item

    function load_world_countries() {
        $.ajax({
            url: "https://corona-stats.online/?format=json",
            type: "get",
            success: function (response) {
                var worldData = response.worldStats;
                var countriesData = response.data;

                display_world_data(worldData);
                display_countries_data(countriesData);
            },
            error: function (error) {
                //Swal.fire({
                //    title: 'Error!',
                //    html: error.responseText,
                //    icon: 'error',
                //    confirmButtonText: '<i class="fa fa-thumbs-down"></i>'
                //})

                toastr.error("Failed to get all countries data","Error");
            }
        });
    }//load_world_countries


    var display_countries_data = function (data) {
        var table = $("#countries-table-body");
        var html = "";

        var selectitem = '<li class="list-inline-item"><a class="waves-effect waves-teal btn-flat btn-view-graph" href="#!" data-country="world">Global</a></li>';
        data.forEach(item => {
            //selectitem += '<option value="' + item.countryCode + '">' + item.country + '</option>';
            selectitem += '<li class="list-inline-item"><a class="waves-effect waves-teal btn-flat btn-view-graph" href="#!" data-country="' + item.countryCode + '">' + item.country + '</a></li>';
            html += "<tr>";
            html += "<td>" + item.country + "</td>";
            html += "<td>" + formatNumber(item.cases) + "</td>";
            html += "<td>" + formatNumber(item.deaths) + "</td>";
            html += "<td>" + formatNumber(item.todayDeaths) + "</td>";
            //html += "<td>" + formatNumber(item.critical) + "</td>";
            html += "<td>" + formatNumber(item.recovered) + "</td>";
            //html += "<td>" + item.confirmed + "</td>";


            html += "</tr>";
        });

        table.html(html);
        $("#input-select-country").html(selectitem);
        $('#table-countries').DataTable({
            "bDestroy": true,
            "order": [[1, "desc"]]
        });
    }// display_countries_data


    var display_world_data = function (data) {
        $("#total-cases").html(formatNumber(data.cases));
        $("#today-cases").html(formatNumber(data.todayCases));
        $("#total-death").html(formatNumber(data.deaths));
        $("#today-death").html(formatNumber(data.todayDeaths));
        $("#recovered").html(formatNumber(data.recovered));
        $("#active").html(formatNumber(data.active));
        $("#critical").html(formatNumber(data.critical));
        $("#confirmed").html(formatNumber(data.confirmed));
    }// display_world_data


    $("body").on("click", ".btn-view-graph", function () {
        var code = $(this).data("country");
        var temp_code = code;
        var global_code = "world";
        if (temp_code == global_code) {
            code = "TL";
        }

        $.ajax({
            url: "https://corona-stats.online/" + code + "?format=json",
            type: "get",
            success: function (response) {
                if (temp_code == global_code) {
                    render_pie(response.worldStats);
                    $("#modal-graph-title").html(response.country);
                } else if (temp_code == "all") {
                    render_bar(response.data);
                    $("#modal-graph-title").html("All countries");
                } else {
                    render_pie(response.data[0]);
                    $("#modal-graph-title").html(response.data[0].country);
                }
                
                $("#modal-graph").modal("open");

            },
            error: function (error) {
                //Swal.fire({
                //    title: 'Error!',
                //    html: error.responseText,
                //    icon: 'error',
                //    confirmButtonText: '<i class="fa fa-thumbs-down"></i>'
                //})
                toastr.error("Error loading country(" + code + ") data ","Error");
            }
        });
    });




    function render_bar(data) {
        var series_data = [];


        for (var i = 0; i < data.length; i++) {
            var item = data[i];
            series_data[i] = {
                name: item.country,
                data: [item.cases, item.todayCases, item.deaths, item.todayDeaths, item.recovered, item.active, item.critical, item.confirmed]
            };

        }

        Highcharts.chart('canvas', {
            chart: {
                type: 'line'
            },
            title: {
                text: 'Covid-19 actual data '
            },
            subtitle: {
                text: 'Source: https://www.worldometers.info/coronavirus/ & https://corona-stats.online/'
            },
            xAxis: {
                categories: ['Cases', 'Today cases', 'Deaths', 'Today deaths', 'Recovered', 'Active', 'Critical', 'Confirmed', 'Sep']
            },
            yAxis: {
                title: {
                    text: 'Nยบ of people'
                }
            },
            plotOptions: {
                line: {
                    dataLabels: {
                        enabled: true
                    },
                    enableMouseTracking: false
                }
            },
            series: series_data
        });

    }// render_bar


    function render_pie(data) {

        Highcharts.chart('canvas', {
            chart: {
                plotBackgroundColor: null,
                plotBorderWidth: null,
                plotShadow: false,
                type: 'pie'
            },
            title: {
                text: 'Covid-19 actual data ' + data.country
            },
            subtitle: {
                text: 'Source: https://www.worldometers.info/coronavirus/ & https://corona-stats.online/'
            },
            tooltip: {
                pointFormat: '{series.name}: <b>{point.y} people</b>'
            },
            accessibility: {
                point: {
                    valueSuffix: 'people'
                }
            },
            plotOptions: {
                pie: {
                    allowPointSelect: true,
                    cursor: 'pointer',
                    dataLabels: {
                        enabled: false
                    },
                    showInLegend: true
                }
            },
            //var series_data = [data.cases,data.todayCases,data.deaths,data.todayDeaths,data.recovered,data.active,data.critical,data.confirmed];
            series: [{
                name: data.country,
                colorByPoint: true,
                data: [{
                    name: 'Cases',
                    y: data.cases,
                    sliced: true,
                    selected: true
                }, {
                    name: 'Today cases',
                    y: data.todayCases
                }, {
                    name: 'Deaths',
                    y: data.deaths
                }, {
                    name: 'Today deaths',
                    y: data.todayDeaths
                }, {
                    name: 'Recovered',
                    y: data.recovered
                },
                {
                    name: 'Active',
                    y: data.active
                },
                {
                    name: 'Critical',
                    y: data.critical
                },
                {
                    name: 'Confirmed',
                    y: data.confirmed
                }
                ]
            }]
        });
    }

    function _reload() {
        setInterval(function () {
            __();
        }, 15 * 1000); // reload every 15 minutos (by default api will load the data every 15 minutes too)
    }//_reload


    function __() {
        load_world_countries();
    }

    function formatNumber(num) {
        return num.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,')
    }


    $('.parallax').parallax();
    $('.modal').modal();
    $('.tabs').tabs({ swipeable: true });
    $('select').formSelect();
    $('.materialboxed').materialbox();
    $('.sidenav').sidenav();

    $('.carousel.carousel-slider').carousel({
        fullWidth: true
    });


    $('#btn-view-tls-table').on("click", function () {
        $("#modal-tls-table").modal("open");
    });

    $("#btn-view-tls-download").on("click", function () {
        $("#modal-tls-download").modal("open");
    });

    $('#btn-view-world-table').on("click", function () {
        $("#modal-world-table").modal("open");
    });

    $('#btn-view-world-graph').on("click", function () {
        $("#modal-countries").modal("open");
    });

    
    
})(jQuery);