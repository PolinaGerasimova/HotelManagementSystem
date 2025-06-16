import { createRouter, createWebHistory } from 'vue-router'
import RoomForm from '../components/RoomForm.vue'
import BookingForm from '../components/BookingForm.vue'
import GuestForm from '../components/GuestForm.vue'
import ServiceForm from '../components/ServiceForm.vue'
import ReportForm from '../components/ReportForm.vue'

const routes = [
  {
    path: '/',
    redirect: '/rooms'
  },
  {
    path: '/rooms',
    name: 'Rooms',
    component: RoomForm
  },
  {
    path: '/bookings',
    name: 'Bookings',
    component: BookingForm
  },
  {
    path: '/guests',
    name: 'Guests',
    component: GuestForm
  },
  {
    path: '/services',
    name: 'Services',
    component: ServiceForm
  },
  {
    path: '/reports',
    name: 'Reports',
    component: ReportForm
  }
]

const router = createRouter({
  history: createWebHistory(),
  routes
})

export default router 