<template>
  <v-container>
    <v-card class="pa-4">
      <v-card-title class="text-h5 mb-4">
        {{ isEdit ? 'Редактировать задачу по уборке' : 'Новая задача по уборке' }}
      </v-card-title>

      <v-form @submit.prevent="submitForm" ref="form">
        <v-row>
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
            <v-select
              v-model="form.taskType"
              :items="taskTypes"
              label="Тип задачи"
              :error-messages="errors.taskType"
              required
            ></v-select>
          </v-col>

          <v-col cols="12" md="6">
            <v-text-field
              v-model="form.scheduledDate"
              label="Запланированная дата"
              type="date"
              :error-messages="errors.scheduledDate"
              required
            ></v-text-field>
          </v-col>

          <v-col cols="12" md="6">
            <v-select
              v-model="form.assignedToId"
              :items="employees"
              item-title="fullName"
              item-value="employeeId"
              label="Назначено"
              :error-messages="errors.assignedToId"
              required
            ></v-select>
          </v-col>

          <v-col cols="12" md="6">
            <v-select
              v-model="form.status"
              :items="taskStatuses"
              label="Статус"
              :error-messages="errors.status"
              required
            ></v-select>
          </v-col>

          <v-col cols="12">
            <v-textarea
              v-model="form.notes"
              label="Примечания"
              :error-messages="errors.notes"
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
            @click="$router.push('/cleaning-tasks')"
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
  roomId: null,
  taskType: '',
  scheduledDate: new Date().toISOString().split('T')[0],
  assignedToId: null,
  status: 'Pending',
  notes: ''
})

const errors = ref({})
const loading = ref(false)
const rooms = ref([])
const employees = ref([])

const taskTypes = [
  { title: 'Ежедневная уборка', value: 'Daily' },
  { title: 'Глубокая уборка', value: 'Deep' },
  { title: 'Уборка после выезда', value: 'Checkout' },
  { title: 'Специальная уборка', value: 'Special' }
]

const taskStatuses = [
  { title: 'Ожидает', value: 'Pending' },
  { title: 'В процессе', value: 'InProgress' },
  { title: 'Завершено', value: 'Completed' },
  { title: 'Отменено', value: 'Cancelled' }
]

const isEdit = computed(() => route.params.id !== undefined)

const loadRooms = async () => {
  try {
    const response = await axios.get('/api/rooms')
    rooms.value = response.data
  } catch (error) {
    console.error('Error loading rooms:', error)
  }
}

const loadEmployees = async () => {
  try {
    const response = await axios.get('/api/employees')
    employees.value = response.data
  } catch (error) {
    console.error('Error loading employees:', error)
  }
}

const loadCleaningTask = async (id) => {
  try {
    const response = await axios.get(`/api/cleaning-tasks/${id}`)
    const cleaningTask = response.data
    form.value = {
      roomId: cleaningTask.roomId,
      taskType: cleaningTask.taskType,
      scheduledDate: cleaningTask.scheduledDate.split('T')[0],
      assignedToId: cleaningTask.assignedToId,
      status: cleaningTask.status,
      notes: cleaningTask.notes
    }
  } catch (error) {
    console.error('Error loading cleaning task:', error)
  }
}

const submitForm = async () => {
  errors.value = {}
  loading.value = true

  try {
    const cleaningTaskData = {
      ...form.value,
      cleaningTaskId: isEdit.value ? parseInt(route.params.id) : 0
    }

    if (isEdit.value) {
      await axios.put(`/api/cleaning-tasks/${route.params.id}`, cleaningTaskData)
    } else {
      await axios.post('/api/cleaning-tasks', cleaningTaskData)
    }

    router.push('/cleaning-tasks')
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
  await Promise.all([loadRooms(), loadEmployees()])
  if (isEdit.value) {
    await loadCleaningTask(route.params.id)
  }
})
</script> 