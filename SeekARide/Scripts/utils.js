$(function() {
		$('#AddressBook').on('click', function () {
			$("#AddUserForm").dialog({
				autoOpen: true,
				position: { my: "center", at: "top+350", of: window },
				width: 1000,
				resizable: false,
				title: 'Add User Form',
				modal: true,
				open: function () {
					
					$(this).load('ShowAddressBook');
				},
				buttons: {
					Cancel: function () {
						$(this).dialog("close");
					}
				}
			});
			return false;
		});
		$('#AddressBook2').on('click', function () {
			$("#AddUserForm").dialog({
				autoOpen: true,
				position: { my: "center", at: "top+350", of: window },
				width: 1000,
				resizable: false,
				title: 'Add User Form',
				modal: true,
				open: function () {

					$(this).load('ShowAddressBook2');
				},
				buttons: {
					Cancel: function () {
						$(this).dialog("close");
					}
				}
			});
			return false;
		});
});
function populateData(street, city, state, zip) {
	$("#street").val(street);
	$("#city").val(city);
	$("#state").val(state);
	$("#zip").val(zip);
	$("#AddUserForm").dialog('close');
}

function populateData2(street, city, state, zip) {
	$("#street2").val(street);
	$("#city2").val(city);
	$("#state2").val(state);
	$("#zip2").val(zip);
	$("#AddUserForm").dialog('close');
}