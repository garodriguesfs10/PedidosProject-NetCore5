import React from 'react'
import { Container, Nav, Row, Col, Button } from 'react-bootstrap'

const Homescreen = () => {


    return (
        <>
            <Container>
                <Row>
                    <Col md={8}>
                        <h1 style={{ textTransform: 'initial' }}>Listagem de pedidos</h1>
                        <p>Aqui você pode visualizar todos os pedidos emitidos</p>
                    </Col>
                    <Col md={4}>
                        <a href="/pedidos">
                            <Button className="btn btn-info rounded" type="button">
                                Consultar
                            </Button>
                        </a>
                    </Col>
                </Row>

                <Nav variant="tabs">
                    <Nav.Item>
                        <Nav.Link href="/pedidos">Pedidos</Nav.Link>
                    </Nav.Item>
                    <Nav.Item>
                        <Nav.Link href="/relatorios">Relatórios</Nav.Link>
                    </Nav.Item>
                </Nav>
            </Container>
        </>
    )
}

export default Homescreen