!(function ($) {
    "use strict";

    var select = "<option selected value=''>Select day</option>";
    for (var i = 1; i < 32; i++) {
        select += '<option value="'+i+'">'+i+'</option>';

    }

    $("#select_day").html(select);


    $("#btn-load-tls-data").on("click", function () {
        var month = $("#select_month").val();
        var day = $("#select_day").val();

        if (month != "" && day != "") {

            //var tls_url_graph = "/api/cases/2020/" + month + "/" + day;
            var tls_url_quarantine = "/api/quarantines/2020/" + month + "/" + day;
            //tls_get_graph(tls_url_graph);
            tls_get_quarantine(tls_url_quarantine);

        } else {
            Swal.fire({
                title: 'Error!',
                html: "Please select month and date!",
                icon: 'error'
            })
        }
    });

    tls_load_today_data();

    function tls_load_today_data() {
        tls_get_graph("/api/cases/today");
        tls_get_quarantine("/api/quarantines/today");
    }//tls_load_today_data

    function tls_get_graph(url) {
        $.ajax({
            url: url,
            type: "get",
            async: true,
            success: function (response) {
                
                tls_render_graph_header(response);
            },
            error: function (error) {
                Swal.fire({
                    title: 'Error!',
                    html: "Error while getting data from /api/cases/today",
                    icon: 'info',
                    confirmButtonText: '<i class="fa fa-thumbs-down"></i>'
                })
            }
        });
    } //tls_get_graph

    function tls_get_quarantine(url) {
        $.ajax({
            url: url,
            type: "get",
            async: true,
            success: function (response) {
                tls_render_quarantine(response);
            },
            error: function (error) {
                Swal.fire({
                    title: 'Error!',
                    html: "Error while getting data from /api/cases/today",
                    icon: 'info',
                    confirmButtonText: '<i class="fa fa-thumbs-down"></i>'
                })
            }
        });
    }//tls_get_quarantine


    function tls_render_graph_header(data) {
        var container = $("#today-tls-item-cases");
        var html = "";
        
        data.forEach(item => {

            switch (item.kazu) {
                case "SUSPEITU":
                    html += tls_create_div_today_item(item.kazu, item.total, "bg-warning");
                    break;
                case "PROVAVEL":
                    html += tls_create_div_today_item(item.kazu, item.total, "bg-info");
                    break;
                case "POSITIVU":
                    html += tls_create_div_today_item(item.kazu, item.total, "bg-danger");
                    break;
                case "NEGATIVU":
                    html += tls_create_div_today_item(item.kazu, item.total, "bg-success");
                    break;
                case "REKUPERA":
                    html += tls_create_div_today_item(item.kazu, item.total, "bg-success");
                    break;
                case "MATE":
                    html += tls_create_div_today_item(item.kazu, item.total, "bg-danger");
                    break;
            }
        });
        if (data.length > 0) {
            container.html(html);
        } else {
            Swal.fire({
                title: 'Info!',
                html: "<i>Default data loaded is for today. Please select the prefered date and month to be loaded</i>",
                icon: 'No Data',
            });
        }
        
    }//tls_render_graph_header


    function tls_render_quarantine(data) {
        var container = $("#today-tls-item-quarantine");
        var html = "";
        var totalKarantinaObrigatorio = 0, totalAutoKarantina = 0,totalPassaKarantina=0, totalItems=0;
        data.forEach(item => {
            html += '<tr>';
            html += '<td>' + item.munisipio + '</td>';
            html += '<td>' + item.obrigatorio + '</td>';
            html += '<td>' + item.auto + '</td>';
            html += '<td>' + item.passa + '</td>';

            var totalItem = (parseInt(item.obrigatorio) + parseInt(item.auto));
            totalKarantinaObrigatorio += parseInt(item.obrigatorio);
            totalAutoKarantina += parseInt(item.auto);
            totalPassaKarantina += parseInt(item.passa);
            totalItems += totalItem;


            html += '<td>' + totalItem +  '</td>';
            html += '</tr>';
        });

        if (data.length > 0) {
            html += '<tr>';
            html += '<td></td>';
            html += '<td>' + totalKarantinaObrigatorio + '</td>';
            html += '<td>' + totalAutoKarantina + '</td>';
            html += '<td>' + totalPassaKarantina + '</td>';
            html += '<td>' + totalItems + '</td>';
            html += '</tr>';
            container.html(html);
        } else {
            Swal.fire({
                title: 'Info!',
                html: "<i>Default data loaded is for today. Please select the prefered date and month to be loaded</i>",
                icon: 'No Data',
            });
        }
    }//tls_render_quarantine


    function tls_create_div_today_item(kazu, total, color) {
        /**
         * 
         * <div class="info-box bg-info">
            <div class="count">6.674</div>
            <div class="title">Confirmed</div>
        </div>
         * */
        var html = '<div class="col"><div class="info-box ' + color + '">';
        html += '<div class="count">' + total + '</div> <br>';
        html += '<div class="title">' + kazu + '</div>';
        html += '</div></div>';

        return html;
    }//tls_create_div_today_item

})(jQuery);