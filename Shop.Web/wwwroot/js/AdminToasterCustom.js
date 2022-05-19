function ShowMessage(title, text, theme) {
    if (theme == 'error') {
        toastr.error(text, title, {
            positionClass: 'toast-top-right',
            progressBar: true
        })
    }

    if (theme == 'success') {
        toastr.success(text, title, {
            positionClass: 'toast-top-right',
            progressBar: true
        })
    }

    if (theme == 'warning') {
        toastr.warning(text, title, {
            positionClass: 'toast-top-right',
            progressBar: true
        })
    }

    if (theme == 'info') {
        toastr.info(text, title, {
            positionClass: 'toast-top-right',
            progressBar: true
        })
    }
}