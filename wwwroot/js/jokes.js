$(document).ready(function () {
    $("#randomJoke").on('click', function (e) {
        $.ajax({
            url: "Home/GetRandomJoke",
            type: "GET",
            success: function (result) {
                if (result.success) {
                    $('#randomJokeHolder').text(result.joke.joke);
                }
            }
        })
    });
    $("#searchJoke").on('click', function (e) {
        var term = $("#searchTerm").val();
        if (term !== "") {


            $.ajax({
                url: "Home/SearchJokes?searchTerm=" + term,
                type: "GET",
                success: function (result) {
                    if (result.success) {
                        $("#smallJokes").empty();
                        $.each(result.jokes.smallJokes, function (index, value) {
                            $("#smallJokes").append("<li>" + value.joke + "</li>")
                        });

                        $("#mediumJokes").empty();
                        $.each(result.jokes.mediumJokes, function (index, value) {
                            $("#mediumJokes").append("<li>" + value.joke + "</li>")
                        });

                        $("#largeJokes").empty();
                        $.each(result.jokes.largeJokes, function (index, value) {
                            $("#largeJokes").append("<li>" + value.joke + "</li>")
                        });
                        $
                    }
                }
            })
        }
    });
})