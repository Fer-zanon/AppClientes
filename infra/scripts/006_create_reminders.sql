-- 006_create_reminders.sql

CREATE TABLE IF NOT EXISTS reminders (
    id UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    business_id UUID NOT NULL,
    customer_id UUID,
    assigned_to_user_id UUID,
    title VARCHAR(200) NOT NULL,
    description TEXT,
    due_at TIMESTAMPTZ NOT NULL,
    status VARCHAR(50) NOT NULL DEFAULT 'pending',
    completed_at TIMESTAMPTZ,
    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    updated_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),

    CONSTRAINT fk_reminders_businesses
        FOREIGN KEY (business_id)
        REFERENCES businesses (id)
        ON DELETE CASCADE,

    CONSTRAINT fk_reminders_customers
        FOREIGN KEY (customer_id)
        REFERENCES customers (id)
        ON DELETE SET NULL,

    CONSTRAINT fk_reminders_users
        FOREIGN KEY (assigned_to_user_id)
        REFERENCES users (id)
        ON DELETE SET NULL,

    CONSTRAINT chk_reminders_status
        CHECK (status IN ('pending', 'completed', 'cancelled'))
);

CREATE INDEX IF NOT EXISTS idx_reminders_business_id
ON reminders (business_id);

CREATE INDEX IF NOT EXISTS idx_reminders_customer_id
ON reminders (customer_id);

CREATE INDEX IF NOT EXISTS idx_reminders_due_at
ON reminders (due_at);

CREATE INDEX IF NOT EXISTS idx_reminders_status
ON reminders (status);
