$(document)
    .ready(function() {
        $('#DeadLineVi')
            .pickadate({
                selectMonths: true, // Creates a dropdown to control month
                selectYears: 15, // Creates a dropdown of 15 years to control year
                today: 'Hôm nay',
                clear: '',
                close: 'Đóng',
                format: 'dd/mm/yyyy',
                monthsFull: [
                    'tháng 2', 'tháng 2', 'tháng 3', 'tháng 4',
                    'tháng 5', 'tháng 6', 'tháng 7', 'tháng 8',
                    'tháng 9', 'tháng 10', 'tháng 11', 'tháng 12'
                ],
                monthsShort: [
                    'tháng 2', 'tháng 2', 'tháng 3', 'tháng 4',
                    'tháng 5', 'tháng 6', 'tháng 7', 'tháng 8',
                    'tháng 9', 'tháng 10', 'tháng 11', 'tháng 12'
                ],
                weekdaysFull: ['Chủ Nhật', 'Thứ 2', 'Thứ 3', 'Thứ 4', 'Thứ 5', 'Thứ 6', 'Thứ 7'],
                weekdaysShort: ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'],
                showWeekdaysFull: true,
                disable: [7, 1],
               
            });
    });
