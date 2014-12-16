var app = angular.module('app', []);

var url = '/api/Task/';

app.factory('taskFactory', function ($http) {
    return {
        getTask: function () {
            return $http.get(url);
        },
        addTask: function (task) {
            return $http.post(url, task);
        },
        deleteTask: function (task) {

            return $http.delete(url + task.Id);
        },
        updateTask: function (task) {
            return $http.put(url + task.Id, task);
        }
    };
});

app.factory('notificationFactory', function () {

    return {
        success: function () {
            alert('success');
        },
        error: function (text) {
            alert('error');
        }
    };
});

app.controller('TaskCtrl', function ($scope, taskFactory, notificationFactory) {
    console.log('0');
    $scope.task = [];
    $scope.newTask = '';
    

    $scope.sort = {
        column: '',
        descending: false
    };
    $scope.changeSorting = function (column) {

        var sort = $scope.sort;

        if (sort.column == column) {
            sort.descending = !sort.descending;
        } else {
            sort.column = column;
            sort.descending = false;
        }
    };



    var getTaskSuccessCallback = function (data, status) {
        $scope.task = data;
    };

    var successCallback = function (data, status, headers, config) {
        notificationFactory.success();

        return taskFactory.getTask().success(getTaskSuccessCallback).error(errorCallback);
    };

    var successPostCallback = function (data, status, headers, config) {
        successCallback(data, status, headers, config).success(function () {

            $scope.task = [];
            $scope.newTask = '';
            taskFactory.getTask().success(getTaskSuccessCallback).error(errorCallback);
        });
    };

    var errorCallback = function (data, status, headers, config) {
        notificationFactory.error(data.ExceptionMessage);
    };



    taskFactory.getTask().success(getTaskSuccessCallback).error(errorCallback);

    $scope.addTask = function () {
        //console.log('add');
        $scope.task = { Desc: this.newTask, CreatedDateTime: new Date().toLocaleString() };

        taskFactory.addTask($scope.task).success(successPostCallback).error(errorCallback);

    };

    $scope.deleteTask = function (task) {
        //console.log('delete');
        taskFactory.deleteTask(task).success(successCallback).error(errorCallback);
    };

    $scope.updateTask = function (task) {
        // console.log('update');
        taskFactory.updateTask(task).success(successCallback).error(errorCallback);
    };

    $scope.filterFunction = function (element) {
        //console.log('filter');
        return element.desc.match(/^Ma/) ? true : false;
    };
});