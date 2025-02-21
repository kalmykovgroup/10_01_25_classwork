import { render, screen } from '@testing-library/react'
import { describe, it} from 'vitest'
import History from "./History.jsx";


describe('History', () => {
    it('renders the History component', () => {
        render(<History searchClick={(text) => this.console.log(text)}></History>)
        screen.debug(); // выводит jsx-файл из компонента приложения в командную строку
    })
})
