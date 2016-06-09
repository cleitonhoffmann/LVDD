function ViewModel() {
    var self = this;
    self.users = ko.observable([]);

    self.refresh = function () {
        $.get('http://192.168.1.144:11863/api/users', function (data) {
            var newUsers = [];
            ko.utils.arrayForEach(data, function (u) {
                var userItem = new UserItem(u.firstName, u.lastName, u.email);
                userItem.openDetails = function (user) {
                    self.details(user);
                    $('.modal').modal();
                }
                newUsers.push(userItem);
            });
            self.users(newUsers);
        });
    }

    self.details = ko.observable({ firstName: '', lastName: '', email: '' });
}

function UserItem(firstName, lastName, email) {
    var self = this;
    self.firstName = ko.observable(firstName);
    self.lastName = ko.observable(lastName);
    self.email = ko.observable(email);
}

(function () {
    "use strict";

    document.addEventListener( 'deviceready', onDeviceReady.bind( this ), false );

    function onDeviceReady() {
        document.addEventListener( 'pause', onPause.bind( this ), false );
        document.addEventListener( 'resume', onResume.bind( this ), false );
        
        var viewModel = new ViewModel();
        ko.applyBindings(viewModel);
        viewModel.refresh();
    };

    function onPause() {
        // TODO: This application has been suspended. Save application state here.
    };

    function onResume() {
        // TODO: This application has been reactivated. Restore application state here.
    };
} )();