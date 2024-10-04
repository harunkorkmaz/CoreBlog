
function PaginationIn(id, totalPage, startPage, url) {

    $(id).twbsPagination('destroy');
    window.pagObj = $(id).twbsPagination({
        totalPages: totalPage,
        visiblePages: 4,
        startPage: startPage,
        first: 'İlk Sayfa',
        prev: 'Önceki',
        next: 'Sonraki',
        last: 'Son Sayfa',
        onPageClick: function (event, page) {

        }
    }).on('page', function (event, page) {
        Pagination(page, id, url);
    });
}

function OnAjaxSuccess(result) {
    debugger;
    Swal.fire(
        result.isSuccess === true ? 'Başarılı' : 'Hata',
        result.message,
        result.isSuccess === true ? 'success' : 'error',
        2000
    );
}

function OnAjaxError(result) {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        timer: 2000,
        html: result.responseJSON.message.join("<br>")
    })
    $(".btn[type='submit']").removeAttr("disabled", "disabled");
}
