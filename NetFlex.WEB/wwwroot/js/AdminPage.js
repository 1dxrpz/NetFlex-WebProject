function RemoveRole(roleId) {
    $.confirm({
        columnClass: 'm',
        title: 'Вы уверены в удалении?',
        content: 'Подтвердите удаление записи!',
        type: 'red',
        Animation: 'zoom',
        closeAnimation: 'zoom',
        autoClose: 'close|10000',
        buttons: {
            tryAgain: {
                text: 'Удалить',
                btnClass: 'btn-red',
                action: function () {
                    //////////////////////// Delete Role
                }
            },
            close: {
                text: 'Отмена'
            }
        }
    });
}

function loadChageUserRoles(userID) {
    $.confirm({
        title: '',
        Animation: 'none',
        closeAnimation: 'none',
        closeIcon: true,
        content: function () {
            var self = this;
            return $.ajax({
                url: '/Admin/GetEditUserRolesPartial?userID=' + userID,
                dataType: 'html',
                method: 'GET'
            }).done(function (response) {
                self.setContent(response);
            }).fail(function () {
                self.setContent('Что-то пошло не так!');
            });
        },
        buttons: {
            savePassword: {
                text: 'Сохранить',
                btnClass: 'btn-green',
                action: function () {
                    var roles = $("#ChangeUserRoles").serialize();
                    console.log(roles);
                    $.ajax({
                        type: 'POST',
                        url: `/Admin/ChangeUserRoles?userId=${userID}&${roles}`,
                        success: function (data) {
                            $.alert({
                                title: 'Успешно!',
                                content: '',
                                closeAnimation: 'scale',
                                type: 'green',
                                buttons: {
                                    close: {
                                        text: "Ok",
                                        btnClass: 'btn-green',
                                    }
                                }
                            });
                        },
                        error: function (jsonData) {
                            //var data = JSON.parse(jsonData.responseText);

                            $.alert({
                                title: 'Что-то пошло не так!',
                                content: "data.detail",
                                closeAnimation: 'scale',
                                type: 'red',
                                buttons: {
                                    close: {
                                        text: "Ok",
                                        btnClass: 'btn-red'
                                    }
                                }
                            });
                        },
                        beforeSend: function (xhr) {
                            xhr.setRequestHeader("XSRF-TOKEN",
                                $('input:hidden[name="__RequestVerificationToken"]').val());
                        }
                    });
                    
                }
            }
        }
    });
}

