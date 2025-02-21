import { afterEach } from  'vitest'
import { cleanup } from  '@testing-library/react'
import  '@testing-library/jest-dom/vitest'

// запускает очистку после каждого тестового случая (например, очистка jsdom)
afterEach ( () => {
    cleanup ();
})