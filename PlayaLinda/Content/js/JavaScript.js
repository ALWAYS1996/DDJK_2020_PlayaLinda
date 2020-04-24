
        $(document).ready(function (){
            alert('hola');
            $("#btn").click(function () {
                var selectFile = ($("#fileUpload"))[0].files[0];
                var dataString = new FormData();

                dataString.append("fileUpload", selectFile);

                $.ajax({

                    url: '@Url.Action("RegistrarGaleriaImagenes", "Basic")',
                    type: 'POST',
                    data: dataString,
                    contentType: false,
                    processData: false,
                    async: false,
                    success: function () {
                        $("#alertControl").html('<div class="alert alert-success" id="alert">' + 'Exito' + '</div>');
                        if (typeof (data.Value) != "undefined") {
                            alert(data.Message);
                        } else { alert('Imagen Subida con exito'); }
                    },
                    error: function (data) {
                    }
                });
            });

                });

