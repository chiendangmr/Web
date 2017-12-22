// Notification.js
// author: Ho Hoang Lan

define(['jquery','js.cookie'], function ($,Cookies) {

	var notifiEnable = Cookies.get('notifiEnable');
	//console.log(typeof notifiEnable);
	//console.log(notifiEnable);
	if (notifiEnable) {
		if (notifiEnable == 'true')
			notifiEnable = true;
		else notifiEnable = false;
	}
	else
		notifiEnable = false;

	if (notifiEnable)
	{
		poll();
	}

	function poll() {
		$.ajax({
			url: "Notification/CheckUpdate",
			type: "GET",
			dataType: "JSON",
			success: function (data) {
				console.log("Has new update:", data);
				if (data)
					UpdateRequest();
			},
			complete: setTimeout(function () {
				poll()
			}, 30000),
			timeout: 3000
		});
	};

	function MarkAsRead(notificationIds) {
		$.ajax({
			url: "Notification/MarkAsRead",
			type: 'POST',
			data: { notificationIds: notificationIds }
		}).done(function (data) {
			console.log("done mark as read");
		});
	}
	function MarkAsUnRead(notificationIds) {
		$.ajax({
			url: "Notification/MarkAsUnRead",
			type: 'POST',
			data: { notificationIds: notificationIds }
		}).done(function (data) {
			console.log("done mark as unread");
		});
	}
	function UpdateRequest() {
		$.ajax({
			url: "Notification/Update",
			type: "GET",
			dateType: "JSON",
			success: function (data) {
				console.log("data:", data);
				UpdateDOM(data);
			}
		});
	}
	function MarkAsReadAll() {
		$.ajax({
			url: "Notification/MarkAsReadAll",
			type: "GET",
			dateType: "JSON",
			success: function (data) {
				console.log(data);
			}
		});
	}
	function OnNotifiCheckBoxCheck() {
		var ids = [];
		var _this = this;
		ids.push(_this.dataset.id);
		if (_this.checked) {
			MarkAsRead(ids);
		}
		else {
			MarkAsUnRead(ids);
		}
	}
	function checkExist(notification) {
		var currentNotifiIds = getNotificationIds();
		return currentNotifiIds.indexOf(notification.Id) <= -1;
	}
	function UpdateDOM(_data) {

		var data = _data.filter(checkExist);

		var reciveNotifiCount = data.length;
		var currentNotifiCount;
		var currentNotifiCountHtml = $("#badge-notification").html();
		if (currentNotifiCountHtml == "") {
			currentNotifiCount = 0;
		} else {
			currentNotifiCount = parseInt(currentNotifiCountHtml);
		}

		var newNotifiCount = currentNotifiCount + reciveNotifiCount;
		$("#badge-notification").html(newNotifiCount);
		var content = "";
		$.each(data, function (i, v) {
			content += '<li class="list-group-header"> <a href="' + v.Link + '">' + v.Content +
				'</a>   <input class="notifi-checkbox" type="checkbox" data-id="' + v.Id + '" />'
				+ '</li>';
		});
		$("#notifi-container").find('ul').prepend(content);
		$('.notifi-checkbox').off().on('click', OnNotifiCheckBoxCheck);
	}

	function getNotificationIds() {
		var ids = [];
		$('.notifi-checkbox').each(function (i, v) {
			ids.push(v.dataset.id);
		});
		return ids;
	}

		$('#btn-notification').click(function () {
			MarkAsReadAll();
			var ids = getNotificationIds();
			MarkAsRead(ids);
			$("#badge-notification").html(""); //Clean counter
			// TOGGLE (SHOW OR HIDE) NOTIFICATION WINDOW.
			$('#notifications').fadeToggle('fast', 'linear', function () {
				if ($('#notifications').is(':hidden')) {
					$('#noti_Button').css('background-color', '#2E467C');
				}
				else $('#noti_Button').css('background-color', '#FFF');        // CHANGE BACKGROUND COLOR OF THE BUTTON.
			});

			$('#noti_Counter').fadeOut('slow');                 // HIDE THE COUNTER.

			return false;
		});
		// HIDE NOTIFICATIONS WHEN CLICKED ANYWHERE ON THE PAGE.
		$(document).click(function () {
			$('#notifications').hide();

			// CHECK IF NOTIFICATION COUNTER IS HIDDEN.
			if ($('#noti_Counter').is(':hidden')) {
				// CHANGE BACKGROUND COLOR OF THE BUTTON.
				$('#noti_Button').css('background-color', '#2E467C');
			}
		});

		$('#notifications').click(function () {
			return false;       // DO NOTHING WHEN CONTAINER IS CLICKED.
		});


});

