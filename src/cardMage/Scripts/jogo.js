$(function () {
    // there's the gallery and the mytrash
    var $gallery = $("#gallery"),
			$myhand = $("#myhand"),
            $mytrash = $("#mytrash");


    function initializeEvents() {

        // resolve the icons behavior with event delegation
        $("ul.gallery > li").click(function (event) {
            var $item = $(this),
				$target = $(event.target);

            if ($target.is("a.ui-icon-trash")) {
                moverCarta($item, $mytrash);
            } else if ($target.is("a.ui-icon-zoomin")) {
                visualizarCarta($target);
            } else if ($target.is("a.ui-icon-refresh")) {
                recycleImage($item);
            }

            return false;
        });
    }

    // image deletion function
    var recycle_icon = "<a href='link/to/recycle/script/when/we/have/js/off' title='Recycle this image' class='ui-icon ui-icon-refresh'>Recycle image</a>";
    function moverCarta($item, destino) {
        $item.fadeOut(function () {
            var $list = $("ul", destino).length ?
					$("ul", destino) :
					$("<ul class='gallery ui-helper-reset'/>").appendTo(destino);

            $item.find("a.ui-icon-trash").remove();
            //$item.append(recycle_icon);
            $item.appendTo($list).fadeIn(function () {
                $item
						.animate({ width: "48px" })
						.find("img")
							.animate({ height: "36px" });
            });
        });
    }

    // image recycle function
    var trash_icon = "<a title='Delete this image' class='ui-icon ui-icon-trash'>Delete image</a>";
    function recycleImage($item) {
        $item.fadeOut(function () {
            $item
					.find("a.ui-icon-refresh")
						.remove()
					.end()
					.css("width", "96px")
					.append(trash_icon)
					.find("img")
						.css("height", "72px")
					.end()
					.appendTo($gallery)
					.fadeIn();
        });
    }



    var myCards = new Array();

    function criarCarta(carta) {
        var $h5 = $('<h5 class="ui-widget-header">' + carta.Nome + '</h5>');
        var $img = $('<img src="' + carta.Imagem + '" alt="' + carta.Nome + '" width="96" height="72" />');
        var $a = $('<a title="Ver Carta">Ver Carta</a>');
        $a.attr('href', carta.Imagem);
        $a.attr('class', 'ui-icon ui-icon-zoomin');
        var $carta = $('<li class="ui-widget-content ui-corner-tr"></li>')
                .append($h5.clone()).append($img.clone()).append($a.clone()).append(trash_icon);

        return $carta.clone();
    }

    // image preview function, demonstrating the ui.dialog used as a modal window
    function visualizarCarta($link) {

        var src = $link.attr("href");
        var title = $link.siblings("img").attr("alt");
        //var $modal = $("img[src$='" + src + "']");

        $('#cartaDialog').attr("title", title);
        $('#imagemCarta').attr("src", src);
        $('#cartaDialog').dialog('open');

    }

    function baixarCarta() {
        alert("teste");
    }

    // Dialog
    $('#cartaDialog').dialog({
        autoOpen: false,
        width: 600,
        modal: true,
        buttons: {
            "Baixar": function () {
                baixarCarta();
                $(this).dialog("close");
            },
            "Fechar": function () {
                $(this).dialog("close");
            }
        }
    });

    function getCarta(id, callback) {
        $.ajax({
            url: "/api/JogoApi",
            data: { id: id },
            type: "GET",
            contentType: "application/json;charset=utf-8",
            statusCode: {
                200: function (carta) {
                    callback(carta);
                },
                404: function () {
                    alert("Erro: Not Found!");
                }
            }
        });
    }

    getCarta(1, function (carta) {
        
        

        myCards[0] = criarCarta(carta);
        $gallery.append(myCards[0]);

        moverCarta(myCards[0], $myhand);

        initializeEvents();
        //
        //$each(
    });
});