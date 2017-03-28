﻿// common startup scripts
var TCTS = TCTS || {}; // TCTS stands for Test Case Tracking System

TCTS.Startup = TCTS.Startup || {};

$.extend(TCTS.Startup,
{
    ButtonConfirm: function() {
        $("input[data-btn-delete]")
            .each(function() {
                $(this)
                    .click(function() {
                        return confirm("You are about to delete an iteration. Are you sure?");
                    });
            });
    }
});

$(function() {
    TCTS.Startup.ButtonConfirm();
});