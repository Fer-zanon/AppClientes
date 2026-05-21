-- 007_create_tags.sql

CREATE TABLE IF NOT EXISTS tags (
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    business_id UUID NOT NULL,
    name VARCHAR(80) NOT NULL,
    color VARCHAR(30),
    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    updated_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),

    CONSTRAINT fk_tags_businesses
        FOREIGN KEY (business_id)
        REFERENCES businesses (id)
        ON DELETE CASCADE,

    CONSTRAINT uq_tags_business_name
        UNIQUE (business_id, name)
);

CREATE INDEX IF NOT EXISTS idx_tags_business_id
ON tags (business_id);
