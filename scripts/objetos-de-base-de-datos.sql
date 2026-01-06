-- ================================================================
-- Create the tables, editioning views, triggers, and sequences
-- Aplication: 
-- Schema: 
-- Date: 
-- Note: 
-- =================================================================
create table images (
    image_id     number primary key
    , file_name    varchar2(255)
    , content_type varchar2(50)
    , image_data   blob
    , file_size    number
    , created_at   timestamp
);
