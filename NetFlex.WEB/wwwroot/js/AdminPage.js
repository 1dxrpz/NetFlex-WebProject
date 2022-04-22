function getFormData($form) {
    var unindexed_array = $form.serializeArray();
    var indexed_array = {};

    $.map(unindexed_array, function (n, i) {
        indexed_array[n['name']] = n['value'];
    });

    return indexed_array;
}

function RemoveRole(id) {
    $.confirm({
        columnClass: 'm',
        title: 'Вы уверены в удалении?',
        content: 'Подтвердите удаление записи!',
        Animation: 'zoom',
        closeAnimation: 'zoom',
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

function RemoveGenre(id) {
    $.confirm({
        columnClass: 'm',
        title: 'Вы уверены в удалении?',
        content: 'Подтвердите удаление записи!',
        Animation: 'zoom',
        closeAnimation: 'zoom',
        buttons: {
            tryAgain: {
                text: 'Удалить',
                btnClass: 'btn-red',
                action: function () {
                    $.ajax({
                        type: 'POST',
                        url: `/Admin/RemoveGenre?id=${id}`,
                        success: function (data) {
                            document.querySelector(`.AllGenres[data-id='${id}']`).remove();
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
function loadAddGenre() {
    $.confirm({
        title: 'Create Genre',
        Animation: 'none',
        closeAnimation: 'none',
        closeIcon: true,
        content: function () {
            var self = this;
            return $.ajax({
                url: '/Admin/GetAddGenrePartial',
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
                    var genre = $("#CreateGenre").serialize();
                    $.ajax({
                        type: 'POST',
                        url: `/Admin/CreateGenre?${genre}`,
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
                                $('.genresTable').append(`<tr class="AllGenres" data-name='${data.genreName}' data-id='${data.id}'>
						            <td class="genrename">${data.genreName}</td>
						            <td>
							            <button type="button" class="btn btn-danger m-2" onclick="RemoveGenre('${data.id}')">
								            Remove
							            </button>
						            </td>
						            <td>
							            <button onclick="loadEditGenre('${data.id}')" type="button" class="btn btn-primary m-2">
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
function loadEditGenre(id) {
    $.confirm({
        title: 'Edit role for user',
        Animation: 'none',
        closeAnimation: 'none',
        closeIcon: true,
        content: function () {
            var self = this;
            return $.ajax({
                url: '/Admin/GetEditGenrePartial?id=' + id,
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
                    var newGenre = $("#EditGenre").val();
                    $.ajax({
                        type: 'POST',
                        url: `/Admin/EditGenre?id=${id}&newName=${newGenre}`,
                        success: function (data) {
                            console.log(data);
                            $(`.AllGenres[data-id=${data.id}]>.genrename`).html(data.genreName);
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

function RemoveMovie(id) {
    $.confirm({
        columnClass: 'm',
        title: 'Вы уверены в удалении?',
        content: 'Подтвердите удаление записи!',
        Animation: 'zoom',
        closeAnimation: 'zoom',
        buttons: {
            tryAgain: {
                text: 'Удалить',
                btnClass: 'btn-red',
                action: function () {
                    $.ajax({
                        type: 'POST',
                        url: `/Admin/RemoveMovie?id=${id}`,
                        success: function (data) {
                            document.querySelector(`.AllMovies[data-id='${id}']`).remove();
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
function loadAddMovie() {
    $.confirm({
        title: 'Create Genre',
        Animation: 'none',
        closeAnimation: 'none',
        closeIcon: true,
        content: function () {
            var self = this;
            return $.ajax({
                url: '/Admin/GetAddMoviePartial',
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
                    var movieData = $("#AddMovieForm").serialize();
                    $.ajax({
                        type: 'POST',
                        url: `/Admin/CreateMovie?${movieData}`,
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
                                $('.moviesTable').append(`<tr class="AllMovies" data-id='${data.id}'>
						            <td class="title">${data.title}</td>
						            <td class="rating">${data.userRating}</td>
						            <td class="age_rating">${data.ageRating}</td>
						            <td>
							            <button type="button" class="btn btn-danger m-2" onclick="RemoveMovie('${data.id}')">
								            Remove
							            </button>
						            </td>
						            <td>
							            <button onclick="loadEditMovie('${data.id}')" type="button" class="btn btn-primary m-2">
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
function loadEditMovie(id) {
    $.confirm({
        title: 'Edit movie',
        Animation: 'none',
        closeAnimation: 'none',
        closeIcon: true,
        content: function () {
            var self = this;
            return $.ajax({
                url: '/Admin/GetEditMoviePartial?id=' + id,
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
                    var model = `${$("#EditMovieForm").serialize()}&Id=${id}`;
                    $.ajax({
                        type: 'POST',
                        url: `/Admin/EditMovie`,
                        data: model,
                        dataType: "json",
                        success: function (data) {
                            console.log(data);
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
                                $(`.AllMovies[data-id=${data.id}]>.title`).html(data.title);
                                $(`.AllMovies[data-id=${data.id}]>.rating`).html(data.userRating);
                                $(`.AllMovies[data-id=${data.id}]>.age_rating`).html(data.ageRating);
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