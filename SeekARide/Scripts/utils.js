$(function() {
	$("#date").datepicker('setStartDate', new Date());
	//$("#time").datetimepicker();


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
					"Add User": function () {
					},
					Cancel: function () {
						$(this).dialog("close");
					}
				}
			});
			return false;
		});
});
