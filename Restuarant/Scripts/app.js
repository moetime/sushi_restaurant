// IIFE
(function () {
    // Document.ready -> link up remove event handler
    var cartValue = 0;
    $(".RemoveLink").click(function () {
        // Get the id from the link
        var recordToDelete = $(this).attr("data-id");
        if (recordToDelete != '') {
            // Perform the ajax post
            $.post("/ShoppingCart/RemoveFromCart/" + recordToDelete, function (data) {
                // Successful requests get here
                // Update the page elements
                if (data.ItemCount == 0) {
                    window.alert("REMOVED" + data.DeleteId);
                    $('#row-' + data.DeleteId).fadeOut('slow');
                }
                else {
                    window.alert("Removed Quantity from" + data.DeleteId);
                    $('#item-count-' + data.DeleteId).text(data.ItemCount);
                }
                $('#cart-total').text(data.CartTotal);
                $('#update-message').text(data.Message);
                $('#cart-status').text('Cart (' + data.CartCount + ')');
            });
        }
    });
})();
//# sourceMappingURL=app.js.map