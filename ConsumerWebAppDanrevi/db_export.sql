USE danrevi_web
-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: Jun 18, 2019 at 12:16 PM
-- Server version: 5.7.23
-- PHP Version: 7.2.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";

--
-- Database: `danrevi_web`
--

-- --------------------------------------------------------

--
-- Table structure for table `articles`
--

CREATE TABLE `articles` (
  `id` int(10) UNSIGNED NOT NULL,
  `title` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `content` mediumtext COLLATE utf8mb4_unicode_ci NOT NULL,
  `user_id` int(10) UNSIGNED NOT NULL,
  `date_created` datetime NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `articles`
--

INSERT INTO `articles` (`id`, `title`, `content`, `user_id`, `date_created`, `created_at`, `updated_at`) VALUES
(1, 'Artikel 1', 'Indhold.....', 3, '2019-06-18 12:14:21', '2019-06-18 10:14:21', '2019-06-18 10:14:21'),
(2, 'Artikel 2', 'Indhold.....', 3, '2019-06-18 12:14:21', '2019-06-18 10:14:21', '2019-06-18 10:14:21'),
(3, 'Artikel 3', 'Indhold.....', 3, '2019-06-18 12:14:21', '2019-06-18 10:14:21', '2019-06-18 10:14:21'),
(4, 'Artikel 4', 'Indhold.....', 3, '2019-06-18 12:14:21', '2019-06-18 10:14:21', '2019-06-18 10:14:21'),
(5, 'Artikel 5', 'Indhold.....', 3, '2019-06-18 12:14:21', '2019-06-18 10:14:21', '2019-06-18 10:14:21'),
(6, 'Artikel 6', 'Indhold.....', 3, '2019-06-18 12:14:21', '2019-06-18 10:14:21', '2019-06-18 10:14:21'),
(7, 'Artikel 7', 'Indhold.....', 3, '2019-06-18 12:14:21', '2019-06-18 10:14:21', '2019-06-18 10:14:21'),
(8, 'Artikel 8', 'Indhold.....', 3, '2019-06-18 12:14:21', '2019-06-18 10:14:21', '2019-06-18 10:14:21'),
(9, 'Artikel 9', 'Indhold.....', 3, '2019-06-18 12:14:21', '2019-06-18 10:14:21', '2019-06-18 10:14:21'),
(10, 'Artikel 10', 'Indhold.....', 3, '2019-06-18 12:14:21', '2019-06-18 10:14:21', '2019-06-18 10:14:21');

-- --------------------------------------------------------

--
-- Table structure for table `article_tag`
--

CREATE TABLE `article_tag` (
  `article_id` int(10) UNSIGNED NOT NULL,
  `tag_id` int(10) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `courses`
--

CREATE TABLE `courses` (
  `id` int(10) UNSIGNED NOT NULL,
  `name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `description` longtext COLLATE utf8mb4_unicode_ci NOT NULL,
  `target_audience` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `location` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `start` datetime NOT NULL,
  `end` datetime NOT NULL,
  `host` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `courses`
--

INSERT INTO `courses` (`id`, `name`, `description`, `target_audience`, `location`, `start`, `end`, `host`, `created_at`, `updated_at`) VALUES
(1, 'Kursus 1', 'Beskrivelse...', 'Alle revisorer', 'Kontor 2', '2019-06-28 22:14:21', '2019-06-29 00:14:21', 'Jens Ringgaard', '2019-06-18 10:14:21', '2019-06-18 10:14:21'),
(2, 'Kursus 2', 'Beskrivelse...', 'Alle revisorer', 'Kontor 1', '2019-07-05 06:14:21', '2019-07-05 06:14:21', 'Jens Ringgaard', '2019-06-18 10:14:21', '2019-06-18 10:14:21'),
(3, 'Kursus 3', 'Beskrivelse...', 'Alle revisorer', 'Kontor 1', '2019-06-27 06:14:21', '2019-06-27 06:14:21', 'Jens Ringgaard', '2019-06-18 10:14:21', '2019-06-18 10:14:21'),
(4, 'Kursus 4', 'Beskrivelse...', 'Alle revisorer', 'Kontor 1', '2019-09-07 06:14:21', '2019-09-07 06:14:21', 'Jens Ringgaard', '2019-06-18 10:14:21', '2019-06-18 10:14:21'),
(5, 'Kursus 5', 'Beskrivelse...', 'Alle revisorer', 'Kontor 1', '2019-07-08 06:14:21', '2019-07-08 06:14:21', 'Jens Ringgaard', '2019-06-18 10:14:21', '2019-06-18 10:14:21'),
(6, 'Kursus 6', 'Beskrivelse...', 'Alle revisorer', 'Kontor 2', '2019-07-08 06:14:21', '2019-07-08 06:14:21', 'Jens Ringgaard', '2019-06-18 10:14:21', '2019-06-18 10:14:21'),
(7, 'Kursus 7', 'Beskrivelse...', 'Alle revisorer', 'Kontor 1', '2019-07-14 06:14:21', '2019-07-14 06:14:21', 'Jens Ringgaard', '2019-06-18 10:14:21', '2019-06-18 10:14:21'),
(8, 'Kursus 8', 'Beskrivelse...', 'Alle revisorer', 'Kontor 1', '2019-09-27 06:14:21', '2019-09-27 06:14:21', 'Jens Ringgaard', '2019-06-18 10:14:21', '2019-06-18 10:14:21'),
(9, 'Kursus 9', 'Beskrivelse...', 'Alle revisorer', 'Kontor 5', '2019-09-18 06:14:21', '2019-09-18 06:14:21', 'Jens Ringgaard', '2019-06-18 10:14:21', '2019-06-18 10:14:21'),
(10, 'Kursus 10', 'Beskrivelse...', 'Alle revisorer', 'Kontor 5', '2019-07-30 06:14:21', '2019-07-30 06:14:21', 'Jens Ringgaard', '2019-06-18 10:14:21', '2019-06-18 10:14:21');

-- --------------------------------------------------------

--
-- Table structure for table `deadlines`
--

CREATE TABLE `deadlines` (
  `id` int(10) UNSIGNED NOT NULL,
  `name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `description` mediumtext COLLATE utf8mb4_unicode_ci NOT NULL,
  `date` datetime NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `deadlines`
--

INSERT INTO `deadlines` (`id`, `name`, `description`, `date`, `created_at`, `updated_at`) VALUES
(1, 'Deadline 1', 'Beskrivelse', '2019-06-19 12:14:21', '2019-06-18 10:14:21', '2019-06-18 10:14:21'),
(2, 'Deadline 2', 'Beskrivelse', '2019-06-28 12:14:21', '2019-06-18 10:14:21', '2019-06-18 10:14:21'),
(3, 'Deadline 3', 'Beskrivelse', '2019-09-26 12:14:21', '2019-06-18 10:14:21', '2019-06-18 10:14:21'),
(4, 'Deadline 4', 'Beskrivelse', '2019-06-25 12:14:21', '2019-06-18 10:14:21', '2019-06-18 10:14:21'),
(5, 'Deadline 5', 'Beskrivelse', '2019-07-04 12:14:21', '2019-06-18 10:14:21', '2019-06-18 10:14:21'),
(6, 'Deadline 6', 'Beskrivelse', '2019-09-26 12:14:21', '2019-06-18 10:14:21', '2019-06-18 10:14:21'),
(7, 'Deadline 7', 'Beskrivelse', '2019-07-03 12:14:21', '2019-06-18 10:14:21', '2019-06-18 10:14:21'),
(8, 'Deadline 8', 'Beskrivelse', '2020-06-17 12:14:21', '2019-06-18 10:14:21', '2019-06-18 10:14:21'),
(9, 'Deadline 9', 'Beskrivelse', '2019-10-16 12:14:21', '2019-06-18 10:14:21', '2019-06-18 10:14:21');

-- --------------------------------------------------------

--
-- Table structure for table `meetings`
--

CREATE TABLE `meetings` (
  `id` int(10) UNSIGNED NOT NULL,
  `name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `description` mediumtext COLLATE utf8mb4_unicode_ci NOT NULL,
  `location` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `host` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `start` datetime NOT NULL,
  `end` datetime NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `meetings`
--

INSERT INTO `meetings` (`id`, `name`, `description`, `location`, `host`, `start`, `end`, `created_at`, `updated_at`) VALUES
(1, 'Møde 1', 'Beskrivelse', 'Kontor 1', 'Jens Ringgaard', '2019-06-18 12:14:21', '2019-06-18 16:14:21', '2019-06-18 10:14:21', '2019-06-18 10:14:21'),
(2, 'Møde 2', 'Beskrivelse', 'Kontor 1', 'Jens Ringgaard', '2019-06-18 12:14:21', '2019-06-18 14:14:21', '2019-06-18 10:14:21', '2019-06-18 10:14:21'),
(3, 'Møde 3', 'Beskrivelse', 'Kontor 1', 'Jens Ringgaard', '2019-06-18 12:14:21', '2019-06-18 15:14:21', '2019-06-18 10:14:21', '2019-06-18 10:14:21');

-- --------------------------------------------------------

--
-- Table structure for table `migrations`
--

CREATE TABLE `migrations` (
  `id` int(10) UNSIGNED NOT NULL,
  `migration` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `batch` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `migrations`
--

INSERT INTO `migrations` (`id`, `migration`, `batch`) VALUES
(1, '2014_10_12_000000_create_users_table', 1),
(2, '2014_10_12_100000_create_password_resets_table', 1),
(3, '2019_02_22_075737_create_roles_table', 1),
(4, '2019_02_22_075950_create_role_user_table', 1),
(5, '2019_02_22_084533_create_courses_table', 1),
(6, '2019_02_22_084604_create_articles_table', 1),
(7, '2019_02_22_090856_create_user_course_table', 1),
(8, '2019_02_26_075940_create_deadline_table', 1),
(9, '2019_04_16_070858_create_tags_table', 1),
(10, '2019_04_16_070944_create_article_tag_table', 1),
(11, '2019_04_24_081327_create_meetings_table', 1);

-- --------------------------------------------------------

--
-- Table structure for table `password_resets`
--

CREATE TABLE `password_resets` (
  `email` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `token` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `roles`
--

CREATE TABLE `roles` (
  `id` int(10) UNSIGNED NOT NULL,
  `name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `description` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `roles`
--

INSERT INTO `roles` (`id`, `name`, `description`, `created_at`, `updated_at`) VALUES
(1, 'Admin', 'Can manage users, content etc.', '2019-06-18 10:14:21', '2019-06-18 10:14:21'),
(2, 'Employee', 'Employee user', '2019-06-18 10:14:21', '2019-06-18 10:14:21');

-- --------------------------------------------------------

--
-- Table structure for table `role_user`
--

CREATE TABLE `role_user` (
  `role_id` int(10) UNSIGNED NOT NULL,
  `user_id` int(10) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `role_user`
--

INSERT INTO `role_user` (`role_id`, `user_id`) VALUES
(2, 1),
(1, 2),
(2, 2),
(1, 3),
(2, 3),
(1, 4),
(2, 4),
(1, 5),
(2, 5),
(1, 6),
(2, 6),
(1, 7),
(2, 7);

-- --------------------------------------------------------

--
-- Table structure for table `tags`
--

CREATE TABLE `tags` (
  `id` int(10) UNSIGNED NOT NULL,
  `tag` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(10) UNSIGNED NOT NULL,
  `name` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `email` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `email_verified_at` timestamp NULL DEFAULT NULL,
  `password` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `remember_token` varchar(100) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL,
  `api_token` varchar(80) COLLATE utf8mb4_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `name`, `email`, `email_verified_at`, `password`, `remember_token`, `created_at`, `updated_at`, `api_token`) VALUES
(1, 'Employee Name', 'employee@example.com', NULL, '$2y$10$.l2kh/lg8.Ucdfh1mnMa.OCBp6loxg8xo5gv48S09vD4Ju2UrEfD6', NULL, '2019-06-18 10:14:21', '2019-06-18 10:14:21', 'YvsrovczoQcc72wMbrzzYxNql8zE2XKPm07qJ8nod05JQTdnQrsNyuj1mewq'),
(2, 'Admin user', 'admin@example.com', NULL, '$2y$10$.SflFJaRWbMcJUGaTAOfKuAOCGWTDLcx1HXVzhuMAOWnDzvdsldCC', NULL, '2019-06-18 10:14:21', '2019-06-18 10:14:21', '2h3MQcvkwjugNpoTT1RR2TvmTwoyBDE43Hglp8garUWXx5NRBlltl5lvCGWl'),
(3, 'Daniel Stuhr Petersen', 'd@stuhrs.dk', NULL, '$2y$10$V/OxxDbluj0/fZxmC0i9f.zQDOzkqRbdtyhq9D46wSb2bagO4BdKK', NULL, '2019-06-18 10:14:21', '2019-06-18 10:14:21', NULL),
(4, 'Kuddi', 'kuddi@mail.com', NULL, '$2y$10$KgqlsYVSLu78v1l2J8rppu2jPQmjxMWcsBsMK0x0wKSKsu6WcxrrO', NULL, '2019-06-18 10:14:21', '2019-06-18 10:14:21', 'aK3ularJrpSdqszB5xmkP8sG0Nvn9C2o6duxZ8M7Dn4apB8tJLWQhcG2hVyD'),
(5, 'Asger', 'asger@mail.com', NULL, '$2y$10$JwpphkO1HpNlM/unj6FjkeKhsVpTkI/eDLDAA/qQ3BIDXcS/5HJrq', NULL, '2019-06-18 10:14:21', '2019-06-18 10:14:21', 'fSbLe4JwiQulrdq32V2G6NQjwSXIK584bvCX1zFzW6k2WL5KEjkwqqcBgepg'),
(6, 'Frederik', 'frederik@mail.com', NULL, '$2y$10$yztOF7kRXkjp1kTThb4W7.gdCHjHv77Bfn60G4IRUIQrQCD3u90Ga', NULL, '2019-06-18 10:14:21', '2019-06-18 10:14:21', 'Qu6uLcnen4pHjZ5BSxbCGVe8YyGZZHyECnnaNFKUbnXKQxWgoRcR4yas2mci'),
(7, 'Andreas', 'andreas@mail.com', NULL, '$2y$10$8la9Z/eJajYHu/B9/lpJVOYGyYctRosiN8/kC8IZlpqyHv9.2FQM.', NULL, '2019-06-18 10:14:21', '2019-06-18 10:14:21', 'xxO3cVvuvpSrxwEvD0sbPa0OgyZO0O4FbQKaWwmfPygCqESH6XV89Lud7awh');

-- --------------------------------------------------------

--
-- Table structure for table `user_course`
--

CREATE TABLE `user_course` (
  `course_id` int(10) UNSIGNED NOT NULL,
  `user_id` int(10) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `user_course`
--

INSERT INTO `user_course` (`course_id`, `user_id`) VALUES
(1, 4),
(1, 6),
(2, 1),
(2, 2),
(2, 3),
(2, 4),
(2, 5),
(2, 6),
(3, 1),
(3, 2),
(3, 3),
(3, 4),
(3, 5),
(3, 6),
(4, 1),
(4, 2),
(4, 3),
(4, 4),
(6, 1),
(7, 4),
(7, 5),
(7, 6),
(8, 1),
(8, 2),
(8, 3),
(8, 4),
(9, 1),
(9, 2),
(9, 3),
(9, 5),
(9, 6),
(10, 1),
(10, 5),
(10, 6);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `articles`
--
ALTER TABLE `articles`
  ADD PRIMARY KEY (`id`),
  ADD KEY `articles_user_id_foreign` (`user_id`),
  ADD KEY `articles_date_created_index` (`date_created`);

--
-- Indexes for table `article_tag`
--
ALTER TABLE `article_tag`
  ADD PRIMARY KEY (`article_id`,`tag_id`),
  ADD KEY `article_tag_tag_id_foreign` (`tag_id`);

--
-- Indexes for table `courses`
--
ALTER TABLE `courses`
  ADD PRIMARY KEY (`id`),
  ADD KEY `courses_start_end_index` (`start`,`end`);

--
-- Indexes for table `deadlines`
--
ALTER TABLE `deadlines`
  ADD PRIMARY KEY (`id`),
  ADD KEY `deadlines_date_index` (`date`);

--
-- Indexes for table `meetings`
--
ALTER TABLE `meetings`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `migrations`
--
ALTER TABLE `migrations`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `password_resets`
--
ALTER TABLE `password_resets`
  ADD KEY `password_resets_email_index` (`email`);

--
-- Indexes for table `roles`
--
ALTER TABLE `roles`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `role_user`
--
ALTER TABLE `role_user`
  ADD PRIMARY KEY (`role_id`,`user_id`),
  ADD KEY `role_user_user_id_foreign` (`user_id`);

--
-- Indexes for table `tags`
--
ALTER TABLE `tags`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `tags_tag_unique` (`tag`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `users_email_unique` (`email`),
  ADD UNIQUE KEY `users_api_token_unique` (`api_token`);

--
-- Indexes for table `user_course`
--
ALTER TABLE `user_course`
  ADD PRIMARY KEY (`user_id`,`course_id`),
  ADD KEY `user_course_course_id_foreign` (`course_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `articles`
--
ALTER TABLE `articles`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `courses`
--
ALTER TABLE `courses`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `deadlines`
--
ALTER TABLE `deadlines`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `meetings`
--
ALTER TABLE `meetings`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `migrations`
--
ALTER TABLE `migrations`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `roles`
--
ALTER TABLE `roles`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `tags`
--
ALTER TABLE `tags`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `articles`
--
ALTER TABLE `articles`
  ADD CONSTRAINT `articles_user_id_foreign` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`);

--
-- Constraints for table `article_tag`
--
ALTER TABLE `article_tag`
  ADD CONSTRAINT `article_tag_article_id_foreign` FOREIGN KEY (`article_id`) REFERENCES `articles` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `article_tag_tag_id_foreign` FOREIGN KEY (`tag_id`) REFERENCES `tags` (`id`) ON DELETE CASCADE;

--
-- Constraints for table `role_user`
--
ALTER TABLE `role_user`
  ADD CONSTRAINT `role_user_role_id_foreign` FOREIGN KEY (`role_id`) REFERENCES `roles` (`id`),
  ADD CONSTRAINT `role_user_user_id_foreign` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`);

--
-- Constraints for table `user_course`
--
ALTER TABLE `user_course`
  ADD CONSTRAINT `user_course_course_id_foreign` FOREIGN KEY (`course_id`) REFERENCES `courses` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `user_course_user_id_foreign` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`) ON DELETE CASCADE;



use mysql

update user set host='%' where host='localhost';


flush privileges;
