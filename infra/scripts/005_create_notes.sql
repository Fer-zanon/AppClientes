-- 005_create_notes.sql

CREATE TABLE IF NOT EXISTS notes (
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    business_id UUID NOT NULL,
    customer_id UUID NOT NULL,
    created_by_user_id UUID,
    text TEXT NOT NULL,
    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    updated_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),

    CONSTRAINT fk_notes_businesses
        FOREIGN KEY (business_id)
        REFERENCES businesses (id)
        ON DELETE CASCADE,

    CONSTRAINT fk_notes_customers
        FOREIGN KEY (customer_id)
        REFERENCES customers (id)
        ON DELETE CASCADE,

    CONSTRAINT fk_notes_users
        FOREIGN KEY (created_by_user_id)
        REFERENCES users (id)
        ON DELETE SET NULL
);

CREATE INDEX IF NOT EXISTS idx_notes_business_id
ON notes (business_id);

CREATE INDEX IF NOT EXISTS idx_notes_customer_id
ON notes (customer_id);
