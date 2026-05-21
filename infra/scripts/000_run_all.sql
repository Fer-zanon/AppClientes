-- 000_run_all.sql
-- Run this file from the same folder using psql if you want to execute all migrations manually.
--
-- Example:
-- psql "$DATABASE_URL" -f 000_run_all.sql

\i 001_create_extensions.sql
\i 002_create_businesses.sql
\i 003_create_users.sql
\i 004_create_customers.sql
\i 005_create_notes.sql
\i 006_create_reminders.sql
\i 007_create_tags.sql
\i 008_create_customer_tags.sql
\i 009_create_updated_at_trigger.sql

-- Optional:
-- \i 010_seed_dev_data.sql
