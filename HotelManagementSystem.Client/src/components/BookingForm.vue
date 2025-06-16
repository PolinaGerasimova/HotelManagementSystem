<template>
  <v-container>
    <v-card class="pa-4">
      <v-card-title class="text-h5 mb-4">
        {{ isEdit ? 'Редактировать бронирование' : 'Новое бронирование' }}
      </v-card-title>

      <v-form @submit.prevent="submitForm" ref="form">
        <v-row>
          <v-col cols="12" md="6">
            <v-select
              v-model="form.guestId"
              :items="guests"
              item-title="fullName"
              item-value="guestId"
              label="Гость"
              :error-messages="errors.guestId"
              required
            ></v-select>
          </v-col>

          <v-col cols="12" md="6">
            <v-select
              v-model="form.roomId"
              :items="rooms"
              item-title="roomNumber"
              item-value="roomId"
              label="Номер"
              :error-messages="errors.roomId"
              required
            ></v-select>
          </v-col>

          <v-col cols="12" md="6">
            <v-text-field
              v-model="form.checkInDate"
              label="Дата заезда"
              type="date"
              :error-messages="errors.checkInDate"
              required
            ></v-text-field>
          </v-col>

          <v-col cols="12" md="6">
            <v-text-field
              v-model="form.checkOutDate"
              label="Дата выезда"
              type="date"
              :error-messages="errors.checkOutDate"
              required
            ></v-text-field>
          </v-col>

          <v-col cols="12" md="6">
            <v-text-field
              v-model="form.totalPrice"
              label="Общая стоимость"
              type="number"
              :error-messages="errors.totalPrice"
              required
            ></v-text-field>
          </v-col>

          <v-col cols="12" md="6">
            <v-select
              v-model="form.status"
              :items="bookingStatuses"
              label="Статус"
              :error-messages="errors.status"
              required
            ></v-select>
          </v-col>

          <v-col cols="12">
            <v-textarea
              v-model="form.specialRequests"
              label="Особые пожелания"
              :error-messages="errors.specialRequests"
            ></v-textarea>
          </v-col>
        </v-row>

        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn
            color="primary"
            type="submit"
            :loading="loading"
            :disabled="loading"
          >
            {{ isEdit ? 'Сохранить' : 'Создать' }}
          </v-btn>
          <v-btn
            color="secondary"
            @click="$router.push('/bookings')"
            :disabled="loading"
          >
            Отмена
          </v-btn>
        </v-card-actions>
      </v-form>
    </v-card>
  </v-container>
</template>

<script setup>
import { ref, onMounted, computed } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import axios from 'axios'

const route = useRoute()
const router = useRouter()
const form = ref({
  guestId: null,
  roomId: null,
  checkInDate: '',
  checkOutDate: '',
  totalPrice: 0,
  status: 'Pending',
  specialRequests: ''
})

const errors = ref({})
const loading = ref(false)
const guests = ref([])
const rooms = ref([])
const bookingStatuses = [
  { title: 'Ожидает', value: 'Pending' },
  { title: 'Подтверждено', value: 'Confirmed' },
  { title: 'Отменено', value: 'Cancelled' },
  { title: 'Завершено', value: 'Completed' }
]

const isEdit = computed(() => route.params.id !== undefined)

const loadGuests = async () => {
  try {
    const response = await axios.get('/api/guests')
    guests.value = response.data
  } catch (error) {
    console.error('Error loading guests:', error)
  }
}

const loadRooms = async () => {
  try {
    const response = await axios.get('/api/rooms')
    rooms.value = response.data
  } catch (error) {
    console.error('Error loading rooms:', error)
  }
}

const loadBooking = async (id) => {
  try {
    const response = await axios.get(`/api/bookings/${id}`)
    const booking = response.data
    form.value = {
      guestId: booking.guestId,
      roomId: booking.roomId,
      checkInDate: booking.checkInDate.split('T')[0],
      checkOutDate: booking.checkOutDate.split('T')[0],
      totalPrice: booking.totalPrice,
      status: booking.status,
      specialRequests: booking.specialRequests
    }
  } catch (error) {
    console.error('Error loading booking:', error)
  }
}

const submitForm = async () => {
  errors.value = {}
  loading.value = true

  try {
    const bookingData = {
      ...form.value,
      bookingId: isEdit.value ? parseInt(route.params.id) : 0
    }

    if (isEdit.value) {
      await axios.put(`/api/bookings/${route.params.id}`, bookingData)
    } else {
      await axios.post('/api/bookings', bookingData)
    }

    router.push('/bookings')
  } catch (error) {
    if (error.response?.data?.errors) {
      errors.value = error.response.data.errors
    } else {
      console.error('Error submitting form:', error)
    }
  } finally {
    loading.value = false
  }
}

onMounted(async () => {
  await Promise.all([loadGuests(), loadRooms()])
  if (isEdit.value) {
    await loadBooking(route.params.id)
  }
})
</script> 