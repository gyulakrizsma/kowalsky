/// <binding Clean='clean' />
'use strict';

var gulp = require('gulp'),
    rimraf = require('rimraf'),
    concat = require('gulp-concat'),
    cssmin = require('gulp-cssmin'),
    less = require('gulp-less'),
    mainBowerFiles = require('main-bower-files');

var paths = {
    webroot: './wwwroot/',
    app: './Client/'
};

paths.concatJsDest = paths.webroot + 'js/app.min.js';
paths.concatCssDest = paths.webroot + 'css/app.min.css';

gulp.task('bower', function () {
    return gulp.src(mainBowerFiles(), { base: './bower_components' })
        .pipe(gulp.dest(paths.webroot + 'lib/'));
});

gulp.task('copyFonts', function () {
    return gulp.src(
            [
                paths.webroot + 'lib/bootstrap/dist/fonts/**',
                paths.webroot + 'lib/font-awesome/fonts/**'
            ])
        .pipe(gulp.dest(paths.webroot + 'fonts'));
});

gulp.task('copyJs', function () {
    return gulp.src(
            [
                paths.app + '**/*'
            ])
        .pipe(gulp.dest(paths.webroot + 'js/client'));
});

gulp.task('less', function () {
    return gulp.src(paths.webroot + 'css/less/app.less')
        .pipe(less())
        .pipe(gulp.dest(paths.webroot + 'css'));
});

gulp.task('clean:js', function (cb) {
    rimraf(paths.concatJsDest, cb);
});

gulp.task('clean:css', function (cb) {
    rimraf(paths.concatCssDest, cb);
});

gulp.task('min:js', function () {
    gulp.src(
            [
                paths.webroot + 'lib/jquery/dist/jquery.js',
                paths.webroot + 'lib/bootstrap/dist/js/bootstrap.js',
                paths.webroot + 'lib/smoothscroll/dist/smoothscroll.js',
                paths.webroot + 'lib/jquery.scrollTo/jquery.scrollTo.js',
                paths.webroot + 'lib/jquery-one-page-nav/jquery.nav.js',
                paths.webroot + 'lib/owl-carousel/owl-carousel/owl.carousel.js',
                paths.webroot + 'lib/jquery.stellar/jquery.stellar.js',
                paths.webroot + 'lib/nivo-lightbox/nivo-lightbox.js',
                paths.webroot + 'lib/wow/dist/wow.js',
                paths.webroot + 'lib/angular/angular.js',
                paths.webroot + 'js/client/app/app.types.js',
                paths.webroot + 'js/client/app/register/register.module.js',
                paths.webroot + 'js/client/app/register/register.services.js',
                paths.webroot + 'js/client/app/register/registerController.js',
                paths.webroot + 'js/home.js'
            ])
        .pipe(concat(paths.concatJsDest))
        .pipe(gulp.dest('.'));
});

gulp.task('min:css', function () {
    gulp.src(
            [
                paths.webroot + 'lib/bootstrap/dist/css/bootstrap.css',
                paths.webroot + 'lib/font-awesome/css/font-awesome.css',
                paths.webroot + 'lib/owl-carousel/**/*.css',
                paths.webroot + 'lib/nivo-lightbox/nivo-lightbox.css',
                paths.webroot + 'lib/nivo-lightbox/themes/default/default.css',
                paths.webroot + 'lib/wow/css/libs/animate.css',
                paths.webroot + 'lib/bootstrap-social/bootstrap-social.css',
                paths.webroot + 'css/app.css'
            ])
        .pipe(concat(paths.concatCssDest))
        .pipe(cssmin())
        .pipe(gulp.dest('.'));
});

gulp.task('watch', function () {
    gulp.watch(paths.app + '**/*', ["copyJs"]);
    gulp.watch(paths.webroot + 'css/less' + '**/*', ["less"]);
});

gulp.task('min', ['clean', 'copyJs', 'min:js', 'less', 'min:css']);
gulp.task('clean', ['clean:js', 'clean:css']);

gulp.task('prod', ['clean', 'min', 'copyFonts']);