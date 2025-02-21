import { render, screen } from '@testing-library/react'
import { describe, it, expect } from 'vitest'
import Search from "./Search.jsx";

/*
test('renders a message', () => {
    const {asFragment, getByText} = render(<Greeting />)
    expect(getByText('Hello, world!')).toBeInTheDocument()
    expect(asFragment()).toMatchInlineSnapshot(`
    <h1>Hello, World!</h1>
  `)
})
*/


/*describe('A truthy statement', () => {
    it('should be equal to 2', () => {
        expect(1+1).toEqual(2)
    })
})*/

describe('Search', () => {
    it('renders the Search component', () => {
        render(<Search />)
        screen.debug(); // выводит jsx-файл из компонента приложения в командную строку
    })
})
