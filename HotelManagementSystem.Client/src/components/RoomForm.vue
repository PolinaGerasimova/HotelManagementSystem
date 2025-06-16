<template>
  <v-form @submit.prevent="submitForm">
    <v-text-field
      v-model="form.roomNumber"
      label="Номер комнаты"
      required
      :error-messages="errors.roomNumber"
    ></v-text-field>

    <v-select
      v-model="form.categoryId"
      :items="categories"
      item-title="categoryName"
      item-value="categoryId"
      label="Категория комнаты"
      required
      :error-messages="errors.categoryId"
    ></v-select>

    <v-text-field
      v-model="form.description"
      label="Описание"
      :error-messages="errors.description"
    ></v-text-field>

    <v-text-field
      v-model="form.maxOccupancy"
      label="Максимальное количество гостей"
      type="number"
      required
      :error-messages="errors.maxOccupancy"
    ></v-text-field>

    <v-text-field
      v-model="form.basePricePerNight"
      label="Базовая цена за ночь"
      type="number"
      required
      :error-messages="errors.basePricePerNight"
    ></v-text-field>

    <v-select
      v-model="form.status"
      :items="roomStatuses"
      label="Статус"
      required
      :error-messages="errors.status"
    ></v-select>

    <v-btn type="submit" color="primary" class="mr-2" :loading="loading">Сохранить</v-btn>
    <v-btn color="secondary" @click="goToBookingForm">К форме бронирования</v-btn>
  </v-form>
</template>

<script>
import { ref, onMounted } from 'vue'
import { useRouter } from 'vue-router'
import axios from 'axios'

export default {
  name: 'RoomForm',
  setup() {
    const router = useRouter()
    const loading = ref(false)
    const categories = ref([])
    const roomStatuses = [
      { title: 'Доступна', value: 'Available' },
      { title: 'Занята', value: 'Occupied' },
      { title: 'Уборка', value: 'Cleaning' },
      { title: 'Обслуживание', value: 'Maintenance' },
      { title: 'Недоступна', value: 'OutOfOrder' }
    ]

    const form = ref({
      roomNumber: '',
      categoryId: null,
      description: '',
      maxOccupancy: 2,
      basePricePerNight: 0,
      status: 'Available'
    })

    const errors = ref({})

    const loadCategories = async () => {
      try {
        const response = await axios.get('/api/roomcategories')
        categories.value = response.data
      } catch (error) {
        console.error('Ошибка при загрузке категорий:', error)
      }
    }

    const submitForm = async () => {
      loading.value = true
      errors.value = {}

      try {
        await axios.post('/api/rooms', form.value)
        router.push('/rooms')
      } catch (error) {
        if (error.response?.data?.errors) {
          errors.value = error.response.data.errors
        } else {
          console.error('Ошибка при сохранении комнаты:', error)
        }
      } finally {
        loading.value = false
      }
    }

    const goToBookingForm = () => {
      router.push('/bookings')
    }

    onMounted(() => {
      loadCategories()
    })

    return {
      form,
      errors,
      loading,
      categories,
      roomStatuses,
      submitForm,
      goToBookingForm
    }
  }
}
</script> 