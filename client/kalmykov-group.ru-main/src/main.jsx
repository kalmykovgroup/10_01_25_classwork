
import { createRoot } from 'react-dom/client'
import './index.css'
import AppRouterProvider from "./AppRouterProvider.jsx";


createRoot(document.getElementById('root')).render(
      <AppRouterProvider/>
)
