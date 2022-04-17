function RemoveRole(id) {
    $.confirm({
        columnClass: 'm',
        title: 'Вы уверены в удалении?',
        content: 'Подтвердите удаление записи!',
        Animation: 'zoom',
        closeAnimation: 'zoom',
        autoClose: 'close',
        buttons: {
            tryAgain: {
                text: 'Удалить',
                btnClass: 'btn-red',
                action: function () {
                    $.ajax({
                        type: 'POST',
                        url: `/Admin/RemoveRole?id=${id}`,
                        success: function (data) {
                            document.querySelector(`.AllRoles[data-id='${id}']`).remove();
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
                            $.alert({
                                title: 'Что-то пошло не так!',
                                closeAnimation: 'none',
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
            },
            close: {
                text: 'Отмена'
            }
        }
    });
}
function loadAddRole() {
    $.confirm({
        title: 'Edit role for user',
        Animation: 'none',
        closeAnimation: 'none',
        closeIcon: true,
        content: function () {
            var self = this;
            return $.ajax({
                url: '/Admin/GetAddRolesPartial',
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
                    var role = $("#CreateRole").serialize();
                    $.ajax({
                        type: 'POST',
                        url: `/Admin/CreateRole?${role}`,
                        success: function (data) {
                            if (data == undefined) {
                                $.alert({
                                    title: 'Что-то пошло не так!',
                                    closeAnimation: 'none',
                                    type: 'red',
                                    buttons: {
                                        close: {
                                            text: "Ok",
                                            btnClass: 'btn-red'
                                        }
                                    }
                                });
                            } else {
                                $('.rolesTable').append(`<tr class="AllRoles" data-name='${data.name}' data-id='${data.id}'>
						            <td>${data.name}</td>
						            <td>
							            <button type="button" class="btn btn-danger m-2" onclick="RemoveRole('${data.id}')">
								            Remove
							            </button>
						            </td>
						            <td>
							            <button onclick="loadEditRole('${data.id}')" type="button" class="btn btn-primary m-2">
								            Edit
							            </button>
						            </td>
					            </tr>`);
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
                            }
                        },
                        error: function (jsonData) {
                            $.alert({
                                title: 'Что-то пошло не так!',
                                closeAnimation: 'none',
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
function loadEditRole(id) {
    $.confirm({
        title: 'Edit role for user',
        Animation: 'none',
        closeAnimation: 'none',
        closeIcon: true,
        content: function () {
            var self = this;
            return $.ajax({
                url: '/Admin/GetEditRolePartial?id=' + id,
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
                    var newRole = $("#EditRole").val();
                    $.ajax({
                        type: 'POST',
                        url: `/Admin/EditRole?id=${id}&newName=${newRole}`,
                        success: function (data) {
                            //$.ajax({
                            //    type: 'GET',
                            //    url: `/Admin/GetRole?id=${id}`,
                            //    success: function (data) {
                            //        $(`.AllRoles[data-id=${data.id}]>.rolename`).html(data.name);
                                    
                            //    }
                            //});
                            $(`.AllRoles[data-id=${data.id}]>.rolename`).html(data.name);
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
                            $.alert({
                                title: 'Что-то пошло не так!',
                                closeAnimation: 'none',
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
function loadChageUserRoles(userID) {
    $.confirm({
        title: 'Edit role for user',
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
                            $.alert({
                                title: 'Что-то пошло не так!',
                                closeAnimation: 'none',
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

