import React from 'react'
import { Navbar } from 'react-bootstrap'

const Header = () => {
    return (
        <header>
            <Navbar bg="light" variant="light" style={{ marginBottom: 40 }}>
                <Navbar.Brand href="/">STI3 - Feito por Gabriel R. R. de Oliveira</Navbar.Brand>
                <Navbar.Toggle />
                <Navbar.Collapse className="justify-content-end">
                    <Navbar.Text style={{ color: 'black' }}>
                        Lins/SP: 23/06/2021
                    </Navbar.Text>
                </Navbar.Collapse>
            </Navbar>
        </header>
    )
}


export default Header