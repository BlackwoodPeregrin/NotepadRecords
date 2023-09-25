CREATE TABLE IF NOT EXISTS users(
  id SERIAL PRIMARY KEY NOT NULL,
  username VARCHAR NOT NULL,
  pswd VARCHAR NOT NULL,
  UNIQUE (id),
  UNIQUE (username)
);

CREATE OR REPLACE FUNCTION insert_user(username VARCHAR, pswd VARCHAR)
RETURNS BOOLEAN AS $$
BEGIN
    BEGIN
        INSERT INTO users (username, pswd) VALUES (username, pswd);
        RETURN TRUE;
    EXCEPTION WHEN others THEN
        RETURN FALSE;
    END;
END;
$$ LANGUAGE plpgsql;

-- таблица с информацией о тренировках по бегу

CREATE TABLE IF NOT EXISTS run(
  user_id INTEGER NOT NULL REFERENCES users (id),
  distance REAL NOT NULL,
  m_time TIME NOT NULL,
  m_date DATE NOT NULL
);

-- таблица с информацией о тренировках по плаванию

CREATE TABLE IF NOT EXISTS swim(
  user_id INTEGER NOT NULL REFERENCES users (id),
  distance REAL NOT NULL,
  m_time TIME NOT NULL,
  m_date DATE NOT NULL
);

-- таблица с информацией о тренировках в упражнении 'планка'

CREATE TABLE IF NOT EXISTS planka(
  user_id INTEGER NOT NULL REFERENCES users (id),
  m_time TIME NOT NULL,
  m_date DATE NOT NULL
);

-- таблица с информацией о тренировках потдягиваний

CREATE TABLE IF NOT EXISTS pull_ups(
  user_id INTEGER NOT NULL REFERENCES users (id),
  m_number INTEGER NOT NULL,
  extra_weight REAL,
  m_time TIME,
  m_date DATE NOT NULL
);

-- таблица с информацией о тренировках отжиманиях

CREATE TABLE IF NOT EXISTS push_ups(
  user_id INTEGER NOT NULL REFERENCES users (id),
  m_number INTEGER NOT NULL,
  extra_weight REAL,
  m_time TIME,
  m_date DATE NOT NULL
);

-- таблица с информацией о тренировках отжиманиях на брусьях

CREATE TABLE IF NOT EXISTS dips(
  user_id INTEGER NOT NULL REFERENCES users (id),
  m_number INTEGER NOT NULL,
  extra_weight REAL,
  m_time TIME,
  m_date DATE NOT NULL
);

-- таблица с информацией о тренировках в выходе силой

CREATE TABLE IF NOT EXISTS muscle_ups(
  user_id INTEGER NOT NULL REFERENCES users (id),
  m_number INTEGER NOT NULL,
  extra_weight REAL,
  m_time TIME,
  m_date DATE NOT NULL
);

-- таблица с информацией о тренировках в жиме лежа

CREATE TABLE IF NOT EXISTS bench_press(
  user_id INTEGER NOT NULL REFERENCES users (id),
  m_number INTEGER NOT NULL,
  rod_weight REAL NOT NULL,
  m_time TIME,
  m_date DATE NOT NULL
);

-- таблица с информацией о тренировках в приседания со штангой

CREATE TABLE IF NOT EXISTS back_squats(
  user_id INTEGER NOT NULL REFERENCES users (id),
  m_number INTEGER NOT NULL,
  rod_weight REAL NOT NULL,
  m_time TIME,
  m_date DATE NOT NULL
);

-- таблица с информацией о тренировках в cтановой тяге

CREATE TABLE IF NOT EXISTS deadlifts(
  user_id INTEGER NOT NULL REFERENCES users (id),
  m_number INTEGER NOT NULL,
  rod_weight REAL NOT NULL,
  m_time TIME,
  m_date DATE NOT NULL
);

-- таблица с информацией о тренировках в подъеме штанги на бицепс

CREATE TABLE IF NOT EXISTS bicep_curls(
  user_id INTEGER NOT NULL REFERENCES users (id),
  m_number INTEGER NOT NULL,
  rod_weight REAL NOT NULL,
  m_time TIME,
  m_date DATE NOT NULL
);

-- таблица с информацией о тренировках в подъеме штанги стоя

CREATE TABLE IF NOT EXISTS overhead_press(
  user_id INTEGER NOT NULL REFERENCES users (id),
  m_number REAL NOT NULL,
  rod_weight REAL NOT NULL,
  m_time TIME,
  m_date DATE NOT NULL
);