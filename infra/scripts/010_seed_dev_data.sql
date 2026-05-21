-- 010_seed_dev_data.sql
-- Optional development seed data.

INSERT INTO businesses (id, name, slug, phone, email)
VALUES (
    '11111111-1111-1111-1111-111111111111',
    'Pelusa Cosas de Mascotas',
    'pelusa-cosas-de-mascotas',
    '+5493410000000',
    'contacto@pelusa.test'
)
ON CONFLICT (slug) DO NOTHING;

INSERT INTO users (id, business_id, full_name, email, password_hash, role)
VALUES (
    '22222222-2222-2222-2222-222222222222',
    '11111111-1111-1111-1111-111111111111',
    'Fernando Zanon',
    'fernando@appclientes.test',
    'change-me',
    'owner'
)
ON CONFLICT (business_id, email) DO NOTHING;

INSERT INTO customers (id, business_id, full_name, phone, email, status, source)
VALUES (
    '33333333-3333-3333-3333-333333333333',
    '11111111-1111-1111-1111-111111111111',
    'María González',
    '+5493411111111',
    'maria@test.com',
    'active',
    'manual'
)
ON CONFLICT (business_id, phone) DO NOTHING;

INSERT INTO tags (id, business_id, name, color)
VALUES (
    '44444444-4444-4444-4444-444444444444',
    '11111111-1111-1111-1111-111111111111',
    'cliente frecuente',
    '#22c55e'
)
ON CONFLICT (business_id, name) DO NOTHING;

INSERT INTO customer_tags (customer_id, tag_id)
VALUES (
    '33333333-3333-3333-3333-333333333333',
    '44444444-4444-4444-4444-444444444444'
)
ON CONFLICT (customer_id, tag_id) DO NOTHING;

INSERT INTO notes (business_id, customer_id, created_by_user_id, text)
VALUES (
    '11111111-1111-1111-1111-111111111111',
    '33333333-3333-3333-3333-333333333333',
    '22222222-2222-2222-2222-222222222222',
    'Prefiere turnos por la tarde.'
);

INSERT INTO reminders (business_id, customer_id, assigned_to_user_id, title, description, due_at)
VALUES (
    '11111111-1111-1111-1111-111111111111',
    '33333333-3333-3333-3333-333333333333',
    '22222222-2222-2222-2222-222222222222',
    'Confirmar próximo turno',
    'Escribir por WhatsApp para confirmar disponibilidad.',
    NOW() + INTERVAL '2 days'
);
