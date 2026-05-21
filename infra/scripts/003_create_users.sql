-- 003_create_users.sql

CREATE TABLE IF NOT EXISTS users (
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    business_id UUID NOT NULL,
    full_name VARCHAR(150) NOT NULL,
    email VARCHAR(150) NOT NULL,
    password_hash TEXT NOT NULL,
    role VARCHAR(50) NOT NULL DEFAULT 'owner',
    is_active BOOLEAN NOT NULL DEFAULT TRUE,
    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    updated_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),

    CONSTRAINT fk_users_businesses
        FOREIGN KEY (business_id)
        REFERENCES businesses (id)
        ON DELETE CASCADE,

    CONSTRAINT uq_users_business_email
        UNIQUE (business_id, email),

    CONSTRAINT chk_users_role
        CHECK (role IN ('owner', 'admin', 'staff'))
);

CREATE INDEX IF NOT EXISTS idx_users_business_id
ON users (business_id);

CREATE INDEX IF NOT EXISTS idx_users_email
ON users (email);
