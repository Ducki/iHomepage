/// <reference path="jquery-2.0.3.js" />

/// <reference path="http://documentcloud.github.com/underscore/underscore-min.js" />
/// <reference path="http://documentcloud.github.com/backbone/backbone-min.js" />

App = {};

App.FeedListModel = Backbone.Model.extend({
    defaults: {
        Feed: "",
        DisplayColumn: "",
        DisplayRow: ""
    }
});

App.FeedListCollection = Backbone.Collection.extend({
    model: App.FeedListModel,
    url: "/Feed/GetAllConfiguredFeeds"
});

App.FeedItemModel = Backbone.Model.extend({
    defaults: {
        Title: "",
        Link: "",
        Description: ""
    }
});

App.FeedCollection = Backbone.Collection.extend({
    model: App.FeedItemModel
});

App.FeedManager = Backbone.Model.extend({

    initialize: function (feedListCollection) {
        this.feedListCollection = feedListCollection;
        this.feedListCollection.fetch();
    },

});

App.AppView = Backbone.View.extend({

    initialize: function () {

        this.feedListCollection = new App.FeedListCollection();

        this.fm = new App.FeedManager(this.feedListCollection);

    },

    render: function () {

    }
});