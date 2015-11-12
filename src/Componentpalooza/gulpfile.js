/// <binding Clean='clean' />
'use strict';
var gulp = require('gulp'),
		path = require('path'),
		del = require('del'),
		babel = require('gulp-babel'),
		concat = require('gulp-concat'),
		cssmin = require('gulp-cssmin'),
		uglify = require('gulp-uglify'),
		sass = require('gulp-sass'),
		maps = require('gulp-sourcemaps'),
    project = require('./project.json');

var paths = {
  webroot: './' + project.webroot + '/'
};

paths.jssrc = 'Assets/js/**/*.js';
paths.csssrc = 'Assets/css/**/*.scss';
paths.js = paths.webroot + 'js/**/*.js';
paths.minJs = paths.webroot + 'js/**/*.min.js';
paths.css = paths.webroot + 'css/**/*.css';
paths.minCss = paths.webroot + 'css/**/*.min.css';
paths.concatJsDest = paths.webroot + 'js/site.min.js';
paths.concatCssDest = paths.webroot + 'css/site.min.css';

gulp.task('clean:js', function() {
  return del(path.join(paths.webroot, 'js'));
});

gulp.task('clean:css', function() {
  return del(path.join(paths.webroot, 'css'));
});

gulp.task('compile:js', function () {
  return gulp.src(paths.jssrc)
    .pipe(babel({
      presets: ['es2015']
    }))
    .pipe(gulp.dest(path.join(paths.webroot, 'js')));
});

gulp.task('compile:css', function () {
  return gulp.src([path.join(paths.webroot, 'lib/pure/pure.css'), paths.csssrc])
    .pipe(sass())
    .pipe(gulp.dest(path.join(paths.webroot, 'css')));
})

gulp.task('min:js', ['compile:js'], function() {
  gulp.src([paths.js, '!' + paths.minJs], {
      base: '.'
    })
		.pipe(maps.init())
    .pipe(concat(paths.concatJsDest))
    .pipe(uglify())
		.pipe(maps.write())
    .pipe(gulp.dest('.'));
});

gulp.task('min:css', ['compile:css'], function() {
  gulp.src([paths.webroot + 'css/pure.css', paths.css, '!' + paths.minCss])
		.pipe(maps.init())
    .pipe(concat(paths.concatCssDest))
    .pipe(cssmin())
		.pipe(maps.write())
    .pipe(gulp.dest('.'));
});

gulp.task('watch', ['min'], function () {
  gulp.watch(paths.jssrc, ['min:js']);
  gulp.watch(paths.csssrc, ['min:css']);
});

gulp.task('clean', ['clean:js', 'clean:css']);
gulp.task('compile', ['compile:js', 'compile:css']);
gulp.task('min', ['min:js', 'min:css']);
