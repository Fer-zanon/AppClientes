-- 008_create_customer_tags.sql

CREATE TABLE IF NOT EXISTS customer_tags (
    customer_id UUID NOT NULL,
    tag_id UUID NOT NULL,
    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),

    PRIMARY KEY (customer_id, tag_id),

    CONSTRAINT fk_customer_tags_customers
        FOREIGN KEY (customer_id)
        REFERENCES customers (id)
        ON DELETE CASCADE,

    CONSTRAINT fk_customer_tags_tags
        FOREIGN KEY (tag_id)
        REFERENCES tags (id)
        ON DELETE CASCADE
);

CREATE INDEX IF NOT EXISTS idx_customer_tags_tag_id
ON customer_tags (tag_id);
