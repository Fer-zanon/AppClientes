-- 004_create_customers.sql

CREATE TABLE IF NOT EXISTS customers (
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    business_id UUID NOT NULL,
    full_name VARCHAR(150) NOT NULL,
    phone VARCHAR(50),
    email VARCHAR(150),
    status VARCHAR(50) NOT NULL DEFAULT 'active',
    source VARCHAR(50),
    notes_summary TEXT,
    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    updated_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),

    CONSTRAINT fk_customers_businesses
        FOREIGN KEY (business_id)
        REFERENCES businesses (id)
        ON DELETE CASCADE,

    CONSTRAINT uq_customers_business_phone
        UNIQUE (business_id, phone),

    CONSTRAINT chk_customers_status
        CHECK (status IN ('active', 'inactive', 'lead', 'archived'))
);

CREATE INDEX IF NOT EXISTS idx_customers_business_id
ON customers (business_id);

CREATE INDEX IF NOT EXISTS idx_customers_full_name
ON customers (full_name);

CREATE INDEX IF NOT EXISTS idx_customers_phone
ON customers (phone);
