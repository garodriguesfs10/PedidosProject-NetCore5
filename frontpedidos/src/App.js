import { Container } from 'react-bootstrap'
import './bootstrap.min.css'
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom'
import Homescreen from './components/Homescreen'
import Header from './components/Header'
import Pedidos from './components/Pedidos'
import Relatorios from './components/Relatorios'
function App() {
  return (
    <Router>
      <Header />
      <Container>
        <Switch>
          <Route path='/' component={Homescreen} exact />
          <Route path='/pedidos' component={Pedidos} />
          <Route path='/relatorios' component={Relatorios} />
        </Switch>
      </Container>
    </Router>
  );
}

export default App;
